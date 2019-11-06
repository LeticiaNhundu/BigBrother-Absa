''''
Capture multiple Faces from multiple users to be stored on a DataBase (dataset directory)
	==> Faces will be stored on a directory: dataset/ (if does not exist, pls create one)
	==> Each face will have a unique numeric integer ID as 1, 2, 3, etc						  

   

'''

import cv2
import os
import pika
import psycopg2
import numpy as np
from PIL import Image
import runpy
import importlib
import face_training


face_detector = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')
con = psycopg2.connect(database="BigBrother", user="postgres", password="root", host="127.0.0.1", port="5433")
cur = con.cursor()
# For each person, enter one numeric face id
abNumber = ''
face_id =0
connection = pika.BlockingConnection(
	pika.ConnectionParameters(host='localhost'))
channel = connection.channel()

channel.queue_declare(queue='Training')




print(face_id)

def callback(ch, method, properties, body):
	abNumber= properties.headers.get('ID')
	cur.execute("SELECT person_id FROM poc.person WHERE abNumber='" + abNumber + "'")
	results = cur.fetchone()
	face_id =results[0]
	print(face_id)
	f = open('Training.mp4','wb')
	f.write(body)
	f.close()
	cam =cv2.VideoCapture("C:/Users/leticia.nhundu/Desktop/BigBrother/BigBrotherPython/Training.mp4")

#print("\n [INFO] Initializing face capture. Look the camera and wait ...")
#cam = cv2.VideoCapture()
	cam.set(3, 640) # set video width
	cam.set(4, 480) # set video height

# Initialize individual sampling face count
	count = 0

	while(True):

					ret, img = cam.read()
					img = cv2.flip(img, 1) # flip video image vertically
					gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
					faces = face_detector.detectMultiScale(gray, 1.3, 5)

					for (x,y,w,h) in faces:

						cv2.rectangle(img, (x,y), (x+w,y+h), (255,0,0), 2)	   
						count += 1

						# Save the captured image into the datasets folder
						cv2.imwrite("dataset/User." + str(face_id) + '.' + str(count) + ".jpg", gray[y:y+h,x:x+w])

						cv2.imshow('video', img)

					k = cv2.waitKey(100) & 0xff # Press 'ESC' for exiting video
					if k == 27:
					  break
					elif count >= 100: # Take 30 face sample and stop video
					  break

		# Do a bit of cleanup
		#print("\n [INFO] Exiting Program and cleanup stuff")
	cam.release()
	cv2.destroyAllWindows()
	importlib.reload(face_training)
channel.basic_consume(
	queue='Training', on_message_callback=callback, auto_ack=True)
print(' [*] Waiting for messages. To exit press CTRL+C')
channel.start_consuming()
