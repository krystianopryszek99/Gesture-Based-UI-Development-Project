import cv2
import mediapipe as mp
import time
import socket
import numpy as np

# IP
SERVER_IP = "127.0.0.1"
#Port
PORT_NUMBER  = 8080

message = "0"
clientSock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
clientSock.connect((SERVER_IP,PORT_NUMBER))

print("Server IP:", SERVER_IP)
print("Port Number:", PORT_NUMBER )

cap = cv2.VideoCapture(0)

# Hand Detection Function
mpHands = mp.solutions.hands
# initialize mediapipe
hands = mpHands.Hands()
 # Function to Draw Landmarks over Hand
mpDraw = mp.solutions.drawing_utils

# Finger tip points
tipIds = [4, 8, 12, 16, 20]

while True:
    success, img = cap.read()
    imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)

    # Process the image and find hands
    results = hands.process(img)
    # List to store the Landmark's Coordinates
    lmList = []
     # checking whether a hand is detected
    if results.multi_hand_landmarks:
        hand_lms = results.multi_hand_landmarks[-1]
        for id, lm in enumerate(hand_lms.landmark):
                # find the height, width, and channel of our image
                h, w, c = img.shape
                # get the central positions of the identified hand points.
                centerx, centery = int(lm.x *w), int(lm.y*h)
                message=str((centerx-320)*(5.7/320))
                lmList.append([id, centerx, centery])
            # Drawing the Landmarks for only One Hand
            # Landmarks will be drawn for the Hand which was Detected First
        mpDraw.draw_landmarks(img, hand_lms, mpHands.HAND_CONNECTIONS)

    hand = None
    # If Hand Detected
    if results.multi_hand_landmarks != None:
        if  lmList[2][1] >  lmList[17][1]:
            hand = "Right"
        else:
            hand = "Left"

    # Stores 1 if finger is Open and 0 if finger is closed
    fingers = []

    # Checking whether a finger is open or closed
    for tipId in tipIds:
        if hand == "Right":
              # Thumb
            if tipId == 4:
                if lmList[tipId][1] > lmList[tipId - 1][1]:
                    fingers.append(1)
                else: 
                    fingers.append(0)
            else:
                if lmList[tipId][2] < lmList[tipId - 2][2]:
                    fingers.append(1)
                else: 
                    fingers.append(0)
        
        elif hand == "Left":
            # Thumb
            if tipId == 4: 
                if lmList[tipId][1] < lmList[tipId - 1][1]:
                    fingers.append(1)
                else: 
                    fingers.append(0)
            else:
                if lmList[tipId][2] < lmList[tipId - 2][2]:
                    fingers.append(1)
                else: 
                    fingers.append(0)

    # Counts the Number of Fingers Open
    allFingers = fingers.count(1)
    print(allFingers)

    # Send message if two fingers open
    if allFingers == 1:
            clientSock.sendto(str(1).encode(), (SERVER_IP, PORT_NUMBER) )
    if allFingers == 2:
            clientSock.sendto(str(2).encode(), (SERVER_IP, PORT_NUMBER) )
    # Send message if 5 fingers open
    if allFingers == 5:
           clientSock.send(message.encode('utf-8'))
           # clientSock.sendto(str(2).encode(), (SERVER_IP, PORT_NUMBER))


    if results.multi_hand_landmarks != None:
        # Display number of fingers 
        cv2.putText(img, str(allFingers), (30, 410), cv2.FONT_HERSHEY_SIMPLEX, 2, (255, 0, 0), 5)

    cv2.imshow("Image", img)
    if cv2.waitKey(1) == ord(' '):
        break