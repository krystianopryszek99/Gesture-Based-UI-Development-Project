import socket
import time

SERVER_IP = '127.0.0.1'
PORT_NUMBER = 8080

clientSock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
clientSock.connect((SERVER_IP,PORT_NUMBER))

while True:
    message = "Hello from server"
    clientSock.send(message.encode('utf-8'))
    print("Sending: " + message)
   
    time.sleep(5.0)