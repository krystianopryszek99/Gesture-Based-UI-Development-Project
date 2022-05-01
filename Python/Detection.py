import socket
import time
import numpy as np
import cv2

SERVER_IP = '127.0.0.1'
PORT_NUMBER = 8080
message = "0"
clientSock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
clientSock.connect((SERVER_IP,PORT_NUMBER))

print("Server IP:", SERVER_IP)
print("Port Number:", PORT_NUMBER)
cap = cv2.VideoCapture(0)

# Colour
lower = np.array([100,100,60])
upper = np.array([150,255,200])


while True:
    # Captures the live stream frame-by-frame
    ret, frame = cap.read()
    # Converts images from BGR to HSV
    hsv_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
    
    # Masking the image to find our color
    mask = cv2.inRange(hsv_frame, lower, upper)

     # Finding contours in mask image
    contours,hierarchy = cv2.findContours(mask,cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_NONE)

     # Finding position of all contours
    if len(contours) != 0:
      try:
        # get the largest contour and its center 
        c = max(contours, key=cv2.contourArea)
         # extract moments of the circle
        M = cv2.moments(c)
       
        # extract the moment values
        cx = int(M['m10']/M['m00'])
        cy = int(M['m01']/M['m00'])

        print(cx,cy)
        x,y,w,h = cv2.boundingRect(c)
        # draw the book contour
        cv2.rectangle(frame, (x, y), (x + w, y + h), (0, 0, 255), 3) 

        message=str((cx-320)*(5.7/320))
        #Converting string to Byte, and sending it to C#
        clientSock.send(message.encode('utf-8'))
        
      except:
           clientSock.send(message.encode('utf-8'))
   
    cv2.imshow('frame',frame)
    cv2.imshow('mask',mask)
    

    key = cv2.waitKey(1)
    if key == 27:
        break

# release the captured frame
cap.release()
# Destroys all of the HighGUI windows.
cv2.destroyAllWindows()