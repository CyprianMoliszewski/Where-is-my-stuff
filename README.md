# **Where is my stuff?**

**Where is my stuff** to aplikacja której celem jest ułatwienie i ustrukturyzowanie sposobu przechowywania rzeczy w domu. 

## **Pierwsze uruchomienie**

### **Baza danych lokalna**

- Nie trzeba nic zmieniać, wystarczy uruchomić aplikację. Plik .mdf zostanie utworzony w folderze bin/debug

### **Baza danych na serwerze**

- W wybranym systemie bazodanowym utworzyć nową bazę danych

- Skopiować i wykonać skrypt uruchomieniowy (Database/schema.sql) w utworzonej bazie danych

- W pliku Database/databaseInit.cs należy zakomentować odpowiednie linijki zgodnie z instrukcjami

- W tym samym pliku ustawić wartość zmiennej "_connStringWimsSqlServer" na odpowiedni connection sting

## **Seedowanie bazy przykładowymi wartościami**

### **Baza danych lokalna**

- Nie trzeba nic robić, przy pierwszym uruchomieniu wykona się to automatycznie

### **Baza danych na serwerze**

- Skopiować i wykonać skrypt uruchomieniowy (Database/seed.sql) w utworzonej wcześniej bazie danych

