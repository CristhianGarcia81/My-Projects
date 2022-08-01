#include <iostream>
#include <stdio.h>
#include <time.h>
#include <conio.h>
#include <windows.h>
#include <stdlib.h>
#include <string.h>

using namespace :: std;

struct datos{
    char nombre[20];
    int  id;
    char destino[30];
    char hora[5];
    int equipo;
}d[60];

class new_nodo
{
   protected:
               int dato;
               new_nodo *next;
   public:
             new_nodo(int);
             new_nodo *get_next(){return next;}
             int get_dato(){return dato;}
             void set_next(new_nodo *x){next=x;}
};

class pila_
{
      private:
              new_nodo *pila;
              new_nodo *pila_aux;
              int tam;
      public:
             pila_();
             bool es_vacia();
             void limpiar_pila(){pila=NULL;}
             void apilar(int);
             void desapilar();
             void imprimir_nodo();
};

new_nodo::new_nodo(int n)
{
      dato=n;
      next=NULL;
}

pila_::pila_()
{
            pila=NULL;
            pila_aux=NULL;
            tam=0;
}

bool pila_::es_vacia()
{
     if(pila==NULL){ return true;}
     else {return false;}
}

void pila_::apilar(int Dato)
{
     new_nodo *ptrNuevo;
     ptrNuevo = new new_nodo(Dato);
     if (es_vacia())
     {
                     pila = ptrNuevo;
                     tam++;
     }
     else
     {
         ptrNuevo->set_next(pila);
         pila = ptrNuevo;
         tam++;
     }
}

void pila_::desapilar()
{
     if (es_vacia()) {}
     else
     {
        pila->get_dato();
         pila = pila->get_next();
         tam--;
     }
}

void pila_::imprimir_nodo()
{
     if(es_vacia()){cout<<"La pila esta vacia!!!"<<endl;}
     else
     {
          pila_aux=pila;

          int pos=tam;
          while (pila_aux->get_next()!=NULL)
          {
                cout<<pila_aux->get_dato()<<endl;
                pila_aux = pila_aux->get_next();
                pos--;
          }
          cout<<pila_aux->get_dato()<<endl;

     }
}

class nodo
{
private:
    int dato;
    nodo *siguiente;
public:
    nodo(int);
    void set_dato(int d){dato=d;}
    int get_dato(){return dato;}
    void set_siguiente(nodo *x){siguiente=x;}
    nodo* siguiente_nodo(){return siguiente;}
};

class cola
{
private:
    nodo *cabeza;
    int tamanio;
public:
    cola();
    bool es_vacia();
    void incluir_nodo(nodo *);
    void eliminar_nodo();
    int buscar_nodo(nodo *);
    bool modificar_nodo(nodo *, int);
    void mostrar_cola();
    nodo* crear_nodo(int);
    int elemento();
    int size();
};

nodo::nodo(int d)
{
    siguiente=NULL;
    dato=d;
}

cola::cola()
{
     cabeza=NULL;
     tamanio=0;
}
bool cola::es_vacia()
{
         if(cabeza==NULL){return true;}
         else {return false;}
}

void cola::incluir_nodo(nodo *x)
{
         if(es_vacia()==true)
         {
              cabeza=x;
              tamanio++;
         }
         else
         {
             nodo *P=cabeza;
             while(P->siguiente_nodo()!=NULL)
             {
                  P=P->siguiente_nodo();
             }
             P->set_siguiente(x);
             tamanio++;
         }
}

void cola::eliminar_nodo()
{
             nodo *p=cabeza;
             cabeza=cabeza->siguiente_nodo();
             tamanio--;
             delete p;

}

int cola::buscar_nodo(nodo *x)
{
         if(es_vacia()==true){return -1;}
         else
         {
             int i=1;
             nodo *P=cabeza;
             while(P!=NULL && P->get_dato()!=x->get_dato())
             {
                           P=P->siguiente_nodo();
                           i++;
             }
             if(P=NULL){return -1;}
             else
             {
                 return i;
             }
         }
}

bool cola::modificar_nodo(nodo *x,int y)
{
         if(es_vacia()==true){return false;}
         else
         {
             nodo *P=cabeza;
             while(P!=NULL && P->get_dato()!=x->get_dato())
             {
                           P=P->siguiente_nodo();
             }
             if(P==NULL)
             {
                        return false;
             }
             else
             {
                 P->set_dato(y);
                 return true;
             }
         }
}

void cola::mostrar_cola()
{
         if(es_vacia()==true){cout<<"lista vacia"<<endl;}
         else
         {
             nodo *P=cabeza;
             while(P!=NULL)
             {
                 cout<<P->get_dato()<<endl;
                 P=P->siguiente_nodo();
             }
         }
}

nodo* cola::crear_nodo(int x)
{
         nodo *P=NULL;
         P=new nodo(x);
         if(P==NULL)
         {
                    throw("no hay memoria suficiente");
         }
         return P;
}

int cola::elemento()
{
    if(es_vacia()==true){return -99;}
    else
    {
        return cabeza->get_dato();
    }
}

int cola::size()
{
    return tamanio;
}

void gotoxy(int x, int y){
	HANDLE hcon;
	hcon = GetStdHandle(STD_OUTPUT_HANDLE);
	COORD dwPos;
	dwPos.X = x;
	dwPos.Y = y;
	SetConsoleCursorPosition(hcon,dwPos);
}

int mono(int b);
void mono2();
void screen();
void bag(int p);
int load();
void llegada();
void avion();
void aterrizaje();
int buscar(int id);
void mostrar(int pos);

int l = 60;
int h = 0, aux1 = 0, aux2 = 0;

int main(){
    int elemento = 0, c2 = 0, n = 0, cont;
    char opc;
    d[c2].id = 1 + rand() % (1000 - 1);
    d[c2].equipo = 1 + rand() % (16 - 1);
    load();
    cola c;
    pila_ p;
    screen();
    do{
    srand(time(NULL));
    d[c2].id = + rand() % (1000 - 1);
    d[c2].equipo = 1 + rand() % (16 - 1);
    gotoxy(0,22);
    cout<<"1)Ingresar"<<endl;
    cout<<"2)Despegar"<<endl;
    cin>>opc;
    switch(opc){
        case '1':{
            if(cont != 14){
            c.incluir_nodo(c.crear_nodo(d[c2].id));
            p.apilar(d[c2].id);
            h++;
            cont++;
            aux1 = h;
            aux2 = h;
            mono(d[c2].id);
            bag(d[c2].equipo);
            c2++;
            d[c2].id = 1 + rand() % (1000 - 1);
            d[c2].equipo = 1 + rand() % (16 - 1);
            l = l - 2;
            }else
            cout<<"Fila fuera de instalaciones, es hora de despegar";
            }break;
        }
    }while(opc != '2');
            llegada();
            system("cls");
            avion();
}

int mono(int b){
    int i = 0, c4 = 0;
        l = l - 2;
        cola c;
    for(i = 0; i < l; i++){
        gotoxy(i+6, 11);cout<<"     "<<b;
        gotoxy(i+7, 12);cout<<"    O ";
        gotoxy(i+8, 13);cout<<"  /|\\";
        gotoxy(i+9, 14);cout<<" / \\";
        Sleep(50);
    }
}

void screen(){
    int j = 0, k = 0;
    gotoxy(35,1);cout<<"Destinos";
    gotoxy(10,2);cout<<"Cd. juarez";
    gotoxy(10,3);cout<<"Morelia";
    gotoxy(35,2);cout<<"Guadalajara";
    gotoxy(35,3);cout<<"Zapopan";
    gotoxy(60,2);cout<<"Monterrey";
    gotoxy(60,3);cout<<"Tonala";
    for(j = 0; j < 81; j++){
        gotoxy(j, 0);cout<<"*";
        for(k = 0; k < 19; k++){
            gotoxy(5, k);cout<<"*";
        }
    }
    for(j = 80; j >= 0; j--){
        gotoxy(j, 18);cout<<"*";
    }
    for(j = 0; j < 81; j++){
        gotoxy(j, 5);cout<<"*";
    }
    for(j = 0; j < 81; j++){
        gotoxy(j, 15);cout<<"*";
    }
    for(k = 0; k < 19; k++){
            gotoxy(77, k);cout<<"*";
        }
    for(k = 0; k < 19; k++){
            gotoxy(80, k);cout<<"*";
        }
}

void bag(int p){
    int c = 0, aux = 0;
    while(c < l){
        gotoxy(c+9, 16);cout<<"  "<<p;
        gotoxy(c+9, 17);cout<<" [  ]";
        Sleep(50);
        gotoxy(40, 30);
        c++;
    }
}



void llegada(){
    int i = 67, q = 30, r = 20, aux = 0;
    int c5 = 5 + rand() % (10 - 5);
    srand(time(NULL));
    c5 = 5 + rand() % (10 - 5);
        while(h > 0){
            c5 = 5 + rand() % (10 - 5);
            aux = c5;
            while(aux >= 0){
            Sleep(1000);
            gotoxy(q,r);cout<<"Atendiendo...  "<<aux--;
            }
        gotoxy(i, 11);cout<<"    ";
        gotoxy(i, 12);cout<<"     ";
        gotoxy(i, 13);cout<<"      ";
        gotoxy(i, 14);cout<<"       ";
        gotoxy(i, 16);cout<<"    ";
        gotoxy(i, 17);cout<<"    ";
        i = i - 4;
        h--;
    }
}

void avion(){
    int c6 = 0, ban = 0, pos = 0;
    char opc2, opc3;
    int ide = 0;
    cola f;
do{
    for(int i = 5; i <= 20; i++){
    gotoxy(i,5);cout<<"*";
        for(int j = 5; j <= 20; j++){
            gotoxy(5,j);cout<<"*";
        }
    }
    for(int i = 19; i >= 5; i--){
    gotoxy(i,20);cout<<"*";
        for(int j = 20; j >= 5; j--){
            gotoxy(20,j);cout<<"*";
        }
    }
    for(int i = 35; i <= 50; i++){
    gotoxy(i,5);cout<<"*";
        for(int j = 5; j <= 20; j++){
            gotoxy(35,j);cout<<"*";
        }
    }
    for(int i = 49; i >= 35; i--){
    gotoxy(i,20);cout<<"*";
        for(int j = 20; j >= 5; j--){
            gotoxy(50,j);cout<<"*";
        }
    }
    for(int i = 65; i <= 80; i++){
    gotoxy(i,5);cout<<"*";
        for(int j = 5; j <= 20; j++){
            gotoxy(65,j);cout<<"*";
        }
    }
    for(int i = 79; i >= 65; i--){
    gotoxy(i,20);cout<<"*";
        for(int j = 20; j >= 5; j--){
            gotoxy(80,j);cout<<"*";
        }
    }
    gotoxy(0, 24);
        cout<<"Seleccione opcion"<<endl;
        cout<<"1) Buscar"<<endl;
        cout<<"2) Aterrizar"<<endl;
        cin>>opc2;
        if(opc2 == '1'){
            cout<<"Ingrese el id a buscar"<<endl;
            cin>>ide;
                if(buscar(ide) >= 0 && buscar(ide) < 17 )
            {
               mostrar(buscar(ide));
               system("pause");
                system("cls");
            }
           else
           {
               cout << "CLAVE NO REGISTRADA" << endl;
           }
                system("pause");
                system("cls");
            }
        }while(opc2 != '2');
        system("cls");
        aterrizaje();
    }



void aterrizaje(){
    srand(time(NULL));
    int i = 0, j = 0, taxi = rand() % 20 + 1;
    int o = 64, aux = 0, q = 30, r = 20;
    pila_ p;
    p.desapilar();
    for(int i = 0; i <= 65; i++){
    gotoxy(i,10);cout<<"*";
    }
    for(int i = 0; i <= 65; i++){
    gotoxy(i,15);cout<<"*";
    }

    while(aux1 > 0){
        mono2();
        aux1--;
    }
        taxi = 5 + rand() % (10 - 5);
        while(aux2 > 0){
            taxi = 5 + rand() % (10 - 5);
            aux = 5 + rand() % (10 - 5);
            while(aux >= 0){
            gotoxy(29,19);cout<<"Taxi numero: "<<taxi;
            Sleep(1000);
            gotoxy(q,r);cout<<"Atendiendo...  "<<aux--;
            }
        gotoxy(o, 11);cout<<"    ";
        gotoxy(o, 12);cout<<"     ";
        gotoxy(o, 13);cout<<"      ";
        gotoxy(o, 14);cout<<"       ";
        gotoxy(o, 16);cout<<"    ";
        gotoxy(o, 17);cout<<"    ";
        o = o - 5;
        aux2--;
    gotoxy(30,20);
    }
}

int s = 60;

void mono2(){
    int i = 0;
    s = s - 5;
    for(i = 0; i < s; i++){
        gotoxy(i+7, 12);cout<<"    O ";
        gotoxy(i+8, 13);cout<<"  /|\\";
        gotoxy(i+9, 14);cout<<" / \\";
        Sleep(50);
    }
}

int buscar (int id)
{
    int i = 0, ban = 0, pos = 0;
    while(i<10 && ban == 0)
    {
        if(id == d[i].id)
        {
            pos = i;
            ban = 1;
        }
        i++;
    }
    return pos;
}

void mostrar (int pos)
{
    cout<<"Nombre "<<d[pos].nombre<<endl;
    cout<<"Destino "<<d[pos].destino<<endl;
    cout<<"Peso de equipaje "<<d[pos].equipo<<endl;
    cout<<"Hora "<<d[pos].hora<<endl;
}

int load(){
    d[0].id = 0;
    d[0].equipo = 0;
    strcpy(d[0].nombre,"Julio");
    strcpy(d[0].destino,"Cd. juarez");
    strcpy(d[0].hora,"11:30");
    d[1].id = 0;
    d[1].equipo = 0;
    strcpy(d[1].nombre,"Cristhian");
    strcpy(d[1].destino,"Zapopan");
    strcpy(d[1].hora,"14:00");
    d[2].id = 0;
    d[2].equipo = 0;
    strcpy(d[2].nombre,"David");
    strcpy(d[2].destino,"Morelia");
    strcpy(d[2].hora,"16:00");
    d[3].equipo = 0;
    d[3].id = 0;
    strcpy(d[3].nombre,"Daniel");
    strcpy(d[3].destino,"Guadalajara");
    strcpy(d[3].hora,"18:00");
    d[4].equipo = 0;
    d[4].id = 0;
    strcpy(d[4].nombre,"Jaime");
    strcpy(d[4].destino,"Monterrey");
    strcpy(d[4].hora,"20:00");
    d[5].equipo = 0;
    d[5].id = 0;
    strcpy(d[5].nombre,"Saul");
    strcpy(d[5].destino,"Tonala");
    strcpy(d[5].hora,"10:00");
    d[6].equipo = 0;
    d[6].id = 0;
    strcpy(d[6].nombre,"Hector");
    strcpy(d[6].destino,"Cd. juarez");
    strcpy(d[6].hora,"11:30");
    d[7].equipo = 0;
    d[7].id = 0;
    strcpy(d[7].nombre,"Noe");
    strcpy(d[7].destino,"Zapopan");
    strcpy(d[7].hora,"14:00");
    d[8].equipo = 0;
    d[8].id = 0;
    strcpy(d[8].nombre,"Marissa");
    strcpy(d[8].destino,"Morelia");
    strcpy(d[8].hora,"16:00");
    d[9].equipo = 0;
    d[9].id = 0;
    strcpy(d[9].nombre,"Julieta");
    strcpy(d[9].destino,"Guadalajara");
    strcpy(d[9].hora,"18:00");
    d[10].equipo = 0;
    d[10].id = 0;
    strcpy(d[10].nombre,"Jose");
    strcpy(d[10].destino,"Monterrey");
    strcpy(d[10].hora,"20:00");
    d[11].equipo = 0;
    d[11].id = 0;
    strcpy(d[11].nombre,"Josthin");
    strcpy(d[11].destino,"Tonala");
    strcpy(d[11].hora,"10:00");
    d[12].equipo = 0;
    d[12].id = 0;
    strcpy(d[12].nombre,"Elisa");
    strcpy(d[12].destino,"Cd. juarez");
    strcpy(d[12].hora,"11:30");
    d[13].equipo = 0;
    d[13].id = 0;
    strcpy(d[13].nombre,"Andrea");
    strcpy(d[13].destino,"Zapopan");
    strcpy(d[13].hora,"14:00");
    d[14].equipo = 0;
    d[14].id = 0;
    strcpy(d[14].nombre,"Alondra");
    strcpy(d[14].destino,"Morelia");
    strcpy(d[14].hora,"16:00");
    d[15].equipo = 0;
    d[15].id = 0;
    strcpy(d[15].nombre,"Ramiro");
    strcpy(d[15].destino,"Guadalajara");
    strcpy(d[15].hora,"18:00");
    d[16].equipo = 0;
    d[16].id = 0;
    strcpy(d[16].nombre,"Luis");
    strcpy(d[16].destino,"Monterrey");
    strcpy(d[16].hora,"20:00");
}
