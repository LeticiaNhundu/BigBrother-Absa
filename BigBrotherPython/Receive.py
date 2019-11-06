import pika
import cv2
import struct
import io

connection = pika.BlockingConnection(
    pika.ConnectionParameters(host='localhost'))
channel = connection.channel()

channel.queue_declare(queue='hello')


def callback(ch, method, properties, body):
   x= properties.headers.get('name')
   #f = open('Leticia.mp4','wb')
   #f.write(body)
   #f.close()
   cam =cv2.VideoCapture("C:/Users/leticia.nhundu/Desktop/BigBrother/Leticia.mp4")
   f = True
   while(f):
    f,img = cam.read() # After some minutes all frames returnes are empty and f is false
                     # This doesn't throws any exception
    
    cv2.imshow("input",img)
    
    cv2.waitKey(1)
channel.basic_consume(
    queue='hello', on_message_callback=callback, auto_ack=True)


print(' [*] Waiting for messages. To exit press CTRL+C')
channel.start_consuming()
