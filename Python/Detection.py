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

while True:
    # Captures the live stream frame-by-frame
    ret, frame = cap.read()
    blur_frame = cv2.GaussianBlur(frame, (5, 5), 0)
    # Converts images from BGR to HSV
    hsv_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
    # Colour
    lower = np.array([102, 80, 2])
    upper = np.array([126, 255, 255])
    # Masking the image to find our color
    mask = cv2.inRange(hsv_frame, lower, upper)
    # The bitwise and of the frame and mask is done so 
    # that only the blue coloured objects are highlighted 
    blue = cv2.bitwise_and(frame, frame, mask=mask)
    # Finding contours in mask image
    contours,hierarchy = cv2.findContours(mask, cv2.RETR_TREE, cv2.CHAIN_APPROX_NONE)
    # Finding position of all contours
    for contour in contours:
        area = cv2.contourArea(contour)

        if area > 5000:
            cv2.drawContours(frame, contour, -1, (0, 255, 0), 3)
            # extract moments of the circle
            M = cv2.moments(contour)
            # extract the moment values
            cx = int(M["m10"] / M["m00"])
            cy = int(M["m01"] / M["m00"])
            print(cx,cy)
            message=str((cx-320)*(5.7/320))
            #Converting string to Byte, and sending it to C#
            clientSock.send(message.encode('utf-8'))
            # draw the book contour
            cv2.circle(frame, (cx, cy), 7, (255, 255, 255), -1)
            cv2.putText(frame, "Blue", (cx - 20, cy - 20), cv2.FONT_HERSHEY_SIMPLEX, 2.5, (255, 255, 255), 3)

    cv2.imshow("Frame", frame)
    cv2.imshow("Blue", blue)

    key = cv2.waitKey(1)
    if key == 27:
        break