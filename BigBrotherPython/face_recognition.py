import cv2
import numpy as np
import datetime
import psycopg2
import os 
import pika
import dlib
from imutils import face_utils
from keras.models import load_model
import face_recognition
from statistics import mode
from utils.datasets import get_labels
from utils.inference import detect_faces
from utils.inference import draw_text
from utils.inference import draw_bounding_box
from utils.inference import apply_offsets
from utils.inference import load_detection_model
from utils.preprocessor import preprocess_input

recognizer = cv2.face.LBPHFaceRecognizer_create()
recognizer.read('trainer/trainer.yml')
cascadePath = "haarcascade_frontalface_default.xml"
faceCascade = cv2.CascadeClassifier(cascadePath);
emotion_model_path = './models/emotion_model.hdf5'
emotion_labels = get_labels('fer2013')
detector = dlib.get_frontal_face_detector()
emotion_classifier = load_model(emotion_model_path)
emotion_offsets = (20, 40)
font = cv2.FONT_HERSHEY_SIMPLEX
con = psycopg2.connect(database="BigBrother", user="postgres", password="root", host="127.0.0.1", port="5433")
cur = con.cursor()
today = datetime.datetime.now()
#iniciate id counter

connection = pika.BlockingConnection(
	pika.ConnectionParameters(host='localhost'))
channel = connection.channel()

channel.queue_declare(queue='Recognition')

# names related to ids: example ==> Marcelo: id=1,	etc
names = ['None', 'lol', 'Themba', 'Leticia','Kgabo','Alex','Taps'] 
connection = pika.BlockingConnection(
	pika.ConnectionParameters(host='localhost'))
channel = connection.channel()

channel.queue_declare(queue='Recognition')


#os.remove("Leticia.mp4")

channel.start_consuming()
# Initialize and start realtime video capture
#cam = cv2.VideoCapture("C:/Users/leticia.nhundu/Pictures/Camera Roll/Leticia.mp4")

emotion_offsets = (20, 40)
EMOTIONS = ["angry" ,"disgust","scared", "happy", "sad", "surprised",
 "neutral"]
predictor = dlib.shape_predictor("shape_predictor_68_face_landmarks.dat")
totalAmount = [0,0,0,0,0,0,0]
averageCount = [0,0,0,0,0,0,0]
finalAmount = 0

# getting input model shapes for inference
emotion_target_size = emotion_classifier.input_shape[1:3]

# starting lists for calculating modes
emotion_window = []
def callback(ch, method, properties, body):
	x= properties.headers.get('name')
	f = open('Recognition.mp4','wb')
	f.write(body)
	f.close()
	cam =cv2.VideoCapture("C:/Users/leticia.nhundu/Desktop/BigBrother/BigBrotherPython/Recognition.mp4")
	cam.set(3, 640) # set video widht
	cam.set(4, 480) # set video height

# Define min window size to be recognized as a face
	minW = 0.1*cam.get(3)
	minH = 0.1*cam.get(4)
# hyper-parameters for bounding boxes shape
	frame_window = 10
	try:
		while True:
#Starts capturing frames from the camera object
					ret, img =cam.read()
					img = cv2.flip(img, 1) # Flip vertically
 # Convert it to Gray Scale
					gray = cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
#Detect and extract faces from the images
					faces = faceCascade.detectMultiScale( 
						gray,
						scaleFactor = 1.2,
						minNeighbors = 5,
						minSize = (int(minW), int(minH)),
					)
# loop through each face and Use the recognizer to recognize the Id of the user and emotion
					for(x,y,w,h) in faces:
						gray_face =gray[y:y+h,x:x+w]
						gray_face = cv2.resize(gray_face, (emotion_target_size))
						cv2.rectangle(img, (x,y), (x+w,y+h), (0,255,0), 2)
						gray_face = preprocess_input(gray_face, True)
						gray_face = np.expand_dims(gray_face, 0)
						gray_face = np.expand_dims(gray_face, -1)
						preds =emotion_classifier.predict(gray_face)
						emotion_label_arg = np.argmax(preds)
						#print(emotion_label_arg)
						score = np.max(preds)
						emotion_text = emotion_labels[emotion_label_arg]
						canvas = np.zeros((250, 300, 3), dtype="uint8")
		
#recognizer is predicting the user Id and confidence of the prediction respectively
					id, confidence = recognizer.predict(gray[y:y+h,x:x+w])
		
		# Check if confidence is less them 100 ==> "0" is perfect match 
					if (confidence < 100):
						print(id)
						
						personId = id	
						
							
						confidence = "	{0}%".format(round(100 - confidence))
			
					else:
						personId = "unknown"
						confidence = "	{0}%".format(round(100 - confidence))
										
				#print(str(personId))
					i=0
					while i<7:
						emotion_name = emotion_labels[i]
						percentage =str(preds[0,i]*100)
						averageCount[i] = averageCount[i] + 1
						totalAmount[i] = totalAmount[i] + preds[0,i]*100
				# print(emotion_name + "scroe " + str(preds[0,i]*100))
				# cur.execute("insert into poc.person_emotions(emotion_fk, person_fk, percentage, emotion_date) values (%s, %s, %s, %s)", (i,personId,percentage,today))
				# con.commit()
						i +=1
		
					name = str(personId) + " is " + emotion_text+ " " + str(score*100)+"%"
		# write the name,emotion and confidance on the screen
	
					cv2.putText(img, name, (x+5,y-5), font, 1, (255,255,255), 2)
					cv2.putText(img, str(confidence), (x+5,y+h-5), font, 1, (255,255,0), 1)	 
	
					cv2.imshow('camera',img) 

					k = cv2.waitKey(10) & 0xff # Press 'ESC' for exiting video
					if k == 27:
						break
	except:
			z=0
			while z<7:
				#print("average amount of " + averageName[z] + " is: ")
				finalAmount = totalAmount[z]/averageCount[z]
				print(finalAmount)
				cur.execute("insert into poc.person_emotions(emotion_fk, person_fk, percentage, emotion_date) values (%s, %s, %s, %s)", (z,personId,finalAmount,today))
				con.commit()
				z += 1	
			cam.release()
			cv2.destroyAllWindows()
channel.basic_consume(
	queue='Recognition', on_message_callback=callback, auto_ack=True)


print(' [*] Waiting for messages. To exit press CTRL+C')
channel.start_consuming()
# Do a bit of cleanup,Close the camera
print("\n [INFO] Exiting Program and cleanup stuff")
con.close()
cam.release()
cv2.destroyAllWindows()
