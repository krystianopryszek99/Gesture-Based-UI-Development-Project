import socket
import time

SERVER_IP = '127.0.0.1'
PORT_NUMBER = 8080

clientSock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
clientSock.connect((SERVER_IP,PORT_NUMBER))

def list2str(inList):
    outStr = ",".join(str(e) for e in inList)
    return outStr

i = -5
while True:
    message = [i + 0.01]
    message = list2str(message)
    
    clientSock.send(message.encode('utf-8'))
    print("Sending: " + message)
    i += 1
    time.sleep(1)