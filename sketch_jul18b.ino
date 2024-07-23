
const int bufferSize = 100; // Buffer size
char inputData[bufferSize]; // Array to store incoming data
int index = 0; // Track current position in array

int konum; // Keep track of current active coil
int bekleme; // Delay between steps -- motor speed

void setup() {
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);

  digitalWrite(8, LOW);
  digitalWrite(9, LOW);
  digitalWrite(10, LOW);
  digitalWrite(11, LOW);

  konum = 8;
  bekleme = 10;
  Serial.begin(9600); // Start serial communication
}

void loop() {
  while (Serial.available() > 0) {
    char incomingByte = Serial.read(); // Read a character from the serial port

    if (incomingByte == '\n') { // Check for end of line character
      inputData[index] = '\0'; // Null-terminate the array
      processData(inputData); // Process the received data
      index = 0; // Reset the index
    } else {
      if (index < bufferSize - 1) { // Ensure we don't exceed buffer size
        inputData[index] = incomingByte; // Add character to array
        index++; // Increment the index
      }
    }
  }
}

void processData(char* data) {
  String command = String(data);
  //Serial.println("Received command: " + command);
  if (command.startsWith("0 ")) {
    int steps = command.substring(2).toInt();
    solaDon(steps);
    Serial.println("sifir");
  } else if (command.startsWith("1 ")) {
    int steps = command.substring(2).toInt();
    sagaDon(steps);
    Serial.println("bir");
  } else {
    Serial.println("Invalid command received."); // Debugging output for invalid commands
  }
}

void solaDon(int steps) {
  for (int i = steps; i > 0; i--) {
    digitalWrite(konum, HIGH);
    delay(bekleme);
    digitalWrite(konum, LOW);
    konumAzalt();
  }
}

void sagaDon(int steps) {
  for (int i = 0; i < steps; i++) {
    digitalWrite(konum, HIGH);
    delay(bekleme);
    digitalWrite(konum, LOW);
    konumArttir();
  }
  
}

void konumArttir() {
  konum++;
  if (konum == 12) {
    konum = 8;
  }
}

void konumAzalt() {
  konum--;
  if (konum == 7) {
    konum = 11;
  }
}
