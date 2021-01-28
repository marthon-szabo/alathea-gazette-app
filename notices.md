# Web in general

## UDP (User Datagram Protocol - the connectionless, lightweight) vs. TCP
- UDP: small packet size; Dont have to create connection before send data; More control on when the data being sent out; Checks data corruptin but doesen't tries to recover, insted it discards or keeps with a warning flag; Doesen't care for lost packets; No congestion control (on a congested/busy network packets get dropped more often)
- TCP: Connection first (3-way-handshake); Delivery acknowledgement (this is why data segments are numbered); Retransmission; In-order delivery (even though segments arrived unordered it will rearrenge them before sending towards the application - so the app doesen't have to); Delays transmission of data when the network is congested
- VS: 
    - TCP needs bigger header; Data doesen't sent always immediately (eg.: if you talk on skype with a busy connection the sound might delay); bigger overhead -retransmissions, acknowledgements- (eg. not good for hd video streaming); stream-oriented (not the app chooses how to split data) - good for text messaging, file transfers, remote access (ssh)
    - UDP: message-oriented (the app sends the data in different pieces eg. mail)

## TCP/IP protocol
- E.g.:
    1. App layer: creates a message
    2. Transport layer: wraps the message inside a segment

## Ports
- In order to let for ***multiple applications to use the same network connection simultaneously 
, like street names have house numbers***. These ports are ***created by the transport layer*** of TCP/IP protocol.

# Web security

## HTTPS
- Uses ***SSL or TLS*** and symmetric key data encryption.

## SSL (Secure Socket Layer)
1. When the web-client connects to a website ***the server sends an ssl sertificate*** that authenticates
the identity of the website.
2. ***The client checks it and if it is trustworthy it sends back an acknowledgement.*** Then the SSL session can be proceed.