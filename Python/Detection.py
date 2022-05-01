#import socket
#import time

#SERVER_IP = '127.0.0.1'
#PORT_NUMBER = 8080

#clientSock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
#clientSock.connect((SERVER_IP,PORT_NUMBER))

#def list2str(inList):
    #outStr = ",".join(str(e) for e in inList)
    #return outStr

#i = -5
#while True:
    #message = [i + 0.01]
    #message = list2str(message)
    
    #clientSock.send(message.encode('utf-8'))
   # print("Sending: " + message)
   # i += 1
   # time.sleep(1)


import cv2

cap = cv2.VideoCapture(0)
cap.set(cv2.CAP_PROP_FRAME_WIDTH, 1280)
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 720)


while True:
    _, frame = cap.read()
    # Color format BGR to HSV
    hsv_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)

    # Identify the center of the screen
    height, width, _ = frame.shape

    cx = int(width / 2)
    cy = int(height / 2)

     # Pick pixel value
    pixel_center = hsv_frame[cy, cx]
    hue_value = pixel_center[0]

    # color recognition is possible with extracting the first value associated with the HSV format
    color = "Undefined"
    if hue_value < 5:
        color = "RED"
    elif hue_value < 22:
        color = "ORANGE"
    elif hue_value < 33:
        color = "YELLOW"
    elif hue_value < 78:
        color = "GREEN"
    elif hue_value < 131:
        color = "BLUE"
    elif hue_value < 170:
        color = "VIOLET"
    else:
        color = "RED"

    # Identify the center of the screen
    pixel_center_bgr = frame[cy, cx]
    b, g, r = int(pixel_center_bgr[0]), int(pixel_center_bgr[1]), int(pixel_center_bgr[2])

     # show all results on screen
    cv2.rectangle(frame, (cx - 220, 10), (cx + 200, 120), (255, 255, 255), -1)
    cv2.putText(frame, color, (cx - 200, 100), 0, 3, (b, g, r), 5)
    cv2.circle(frame, (cx, cy), 5, (25, 25, 25), 3)

    cv2.imshow("Frame", frame)
    key = cv2.waitKey(1)
    if key == 27:
        break

cap.release()
cv2.destroyAllWindows()