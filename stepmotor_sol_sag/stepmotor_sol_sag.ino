//fonksiyonlardan ve dongulerden faydalanan bir program yazalım...

//o anda hangi bobin aktif onu tutacak
int konum;

//her bir adim arasindaki bekleme suresi -- yani motorun hizi
int bekleme;


void setup() {
  pinMode(8,OUTPUT);
  pinMode(9,OUTPUT);
  pinMode(10,OUTPUT);
  pinMode(11,OUTPUT);

  digitalWrite(8, LOW);
  digitalWrite(9, LOW);
  digitalWrite(10, LOW);
  digitalWrite(11, LOW);

  konum = 8;
  bekleme = 10;
}

void loop() {
   solaDon(500);
   delay(1000);
   solaDon(100);
}


void solaDon(int adim){
   for(int i = adim ; i > 0 ; i--){
     digitalWrite(konum, HIGH);
     delay(bekleme);
     digitalWrite(konum, LOW);
     konumArttir();
   }
}

void sagaDon(int adim){
   for(int i = 0 ; i < adim ; i++){
     digitalWrite(konum, HIGH);
     delay(bekleme);
     digitalWrite(konum, LOW);
     konumArttir();
   }
}

void konumArttir(){
  konum++;
  if(konum == 12){
    konum = 8;
  }
}
