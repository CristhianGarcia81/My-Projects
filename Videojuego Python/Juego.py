import pygame, sys
from pygame.locals import *
import random
from Clases import Nota, TeclaD, TeclaF, TeclaG, TeclaH, TeclaJ, TeclaK, TeclaL, Apuntador
from time import perf_counter

pygame.init()
####SE CREA LA VENTANA####
ventana = pygame.display.set_mode((610, 570))
pygame.display.set_caption("MusicRehab")

####FONDOS#######
Piano = pygame.image.load("Assets/Piano.png")
Mainmenu = pygame.image.load("Assets/Menu.jpg")
fondo = pygame.image.load("Assets/fondo.jpg")
menu_musica = pygame.image.load("Assets/Music_Selection.png")

####VARIABLES####
jugando = False
contPos = 0
contPos2 = 0
pos = 0
score = 0
scoreScreen = False
point = 3
wait = 0
band = 0
music = 0
posApunt = 10
music_select = False
Tutorial = -1
colorTeclas = (0, 0, 255)
contador = 0
tipoFuente = "Arial Black"
tam = 30
tamTeclas = 0
fuente = pygame.font.SysFont(tipoFuente, tam)
colorTexto = (255, 255, 255)
listaNota = []
listaTeclas = []
####LISTA DE NOMBRES DE LAS PIEZAS DISPONIBLES
listaMusica = ["Estrellita", "Mario Theme", "Sadness and Sorrow 8 bits", "Fur Elise", "Hallelujah"]
listaTutorial = ["Tutorial_1", "Tutorial_2", "Tutorial_3", "Tutorial_4", "Tutorial_5", "Tutorial_6"]
TeclaD = TeclaD(0, 200)
TeclaF = TeclaF(87, 200)
TeclaG = TeclaG(174, 200)
TeclaH = TeclaH(261, 200)
TeclaJ = TeclaJ(348, 200)
TeclaK = TeclaK(435, 200)
TeclaL = TeclaL(522, 200)
listaTeclas = [TeclaD, TeclaF, TeclaG, TeclaH, TeclaJ, TeclaK, TeclaL]
####SONIDOS####
Selection = pygame.mixer.Sound("Sonidos/Piano_Select.aiff")

####FUNCIONES####
apuntador = Apuntador(500, posApunt)
def cargarNotas(x, y):
    nota = Nota(x, y)
    listaNota.append(nota)

####CICLO PRINCIPAL####
while True:
    ####SE CARGA EL MENU PRINCIPAL####
    if jugando == False and Tutorial == -1:
        ventana.blit(Mainmenu, (0, 0))
        Tutorial = 0
    ####SE CARGAN LAS TECLAS DEL PIANO####
    elif wait == 0 and jugando == True and music_select == True and music == 1 and scoreScreen == False:
        ventana.blit(fondo, (0, 0))
        for teclas in listaTeclas:
            teclas.dibujar(ventana)
        texto = fuente.render("Puntos: " + str(score), True, colorTexto)
        ventana.blit(texto, (400, 0))
        ####SE VERIFICA SI YA SE SELECCIONO UNA PIEZA####
    if jugando == True and music_select == True:
        music = 1
    ####SE VERIFICA SI YA SE TERMINÓ LA PIEZA####
    if music == 1 and jugando == True and pygame.mixer.music.get_pos() == -1:
        scoreScreen = True
    if scoreScreen == True:
        ventana.fill((205, 205, 205))
        texto = fuente.render("¡Pieza Completada!", True, colorTexto)
        ventana.blit(texto, (150, 245))
        texto = fuente.render("Su puntaje fue: " + str(score), True, colorTexto)
        ventana.blit(texto, (150, 275))

    ####GENERADOR DE LAS NOTAS####
    if wait == 0 and jugando == True and music_select == True and music == 1 and scoreScreen == False:
        point = 3
        tiempo = perf_counter()
        if tiempo - contador > 1:
            contador = tiempo
            posX = random.randrange(0, 522, 87)
            posY = 0
            cargarNotas(posX, posY)
    ####DETECTA LAS COLISIONES DE LAS NOTAS CON LAS TECLAS DEL PIANO Y PAUSA LA MUSICA####
        if len(listaNota) > 0:
            for x in listaNota:
                if jugando == True:
                    x.dibujar(ventana)
                    if wait == 0:
                        x.recorrido()
                    for i in listaTeclas:
                        if x.rect.colliderect(listaTeclas[tamTeclas].rect):
                            wait = 1
                            pygame.mixer.music.pause()
                        else:
                            tamTeclas += 1
                    tamTeclas = 0
    ####CARGA EL TUTORIAL####
    for evento in pygame.event.get():
        if evento.type == MOUSEBUTTONDOWN and Tutorial != 6 and jugando == False:
            if band == 0:
                pygame.mixer.Sound.play(Selection)
                band = 1
            ventana.fill((0, 0, 0))
            Tutorial_image = pygame.image.load("Assets/" + listaTutorial[Tutorial] + ".png")
            Tutorial += 1
            ventana.blit(Tutorial_image, (0, 0))
        elif evento.type == MOUSEBUTTONDOWN and jugando == False and Tutorial == 6:
                jugando = True
                ventana.blit(fondo, (0, 0))
        ####CARGA LA PANTALLA DE PUNTUACION TOTAL Y REINICIA LAS VARIABLES####
        elif evento.type == MOUSEBUTTONDOWN and scoreScreen == True:
            music = 0
            listaNota.clear()
            band = 0
            wait = 0
            music_select = False
            point = 3
            score = 0
            scoreScreen = False
    ####DETECTA LAS TECLAS QUE DEBEN SER PRESIONADAS####
        elif evento.type == KEYDOWN:
            if jugando == True and music_select == True and music == 1:
                if evento.key == K_d and wait == 1 and listaNota[0].rect.left == 0:
                    score = score + point
                    listaNota.remove(listaNota[0])
                    wait = 0
                    pygame.mixer.music.unpause()
                elif evento.key == K_f and wait == 1 and listaNota[0].rect.left == 87:
                    score = score + point
                    listaNota.remove(listaNota[0])
                    wait = 0
                    pygame.mixer.music.unpause()
                elif evento.key == K_g and wait == 1 and listaNota[0].rect.left == 174:
                    score = score + point
                    listaNota.remove(listaNota[0])
                    wait = 0
                    pygame.mixer.music.unpause()
                elif evento.key == K_h and wait == 1 and listaNota[0].rect.left == 261:
                    score = score + point
                    listaNota.remove(listaNota[0])
                    wait = 0
                    pygame.mixer.music.unpause()
                elif evento.key == K_j and wait == 1 and listaNota[0].rect.left == 348:
                    score = score + point
                    listaNota.remove(listaNota[0])
                    wait = 0
                    pygame.mixer.music.unpause()
                elif evento.key == K_k and wait == 1 and listaNota[0].rect.left == 435:
                    score = score + point
                    listaNota.remove(listaNota[0])
                    wait = 0
                    pygame.mixer.music.unpause()
                elif evento.key == K_l and wait == 1 and listaNota[0].rect.left == 522:
                    score = score + point
                    listaNota.remove(listaNota[0])
                    wait = 0
                    pygame.mixer.music.unpause()
                else:
                    if point != 1:
                        point -= 1
    ####CARGA EL MENU DE SELECCION DE PIEZAS####
        if jugando == True and music_select == False and  music == 0:
            ventana.fill((0, 0, 0))
            contPos = 0
            pos = 0
            ventana.blit(menu_musica, (0, 0))
            for cancion in listaMusica:
                texto = fuente.render(listaMusica[pos], True, colorTexto)
                ventana.blit(texto, (50, (contPos * 50) + 10))
                contPos += 1
                pos += 1
            apuntador.dibujar(ventana)
        ####CARGA LA MUSICA ANTES DE SELECCIONAR UNA OPCION####
            if pygame.mixer.music.get_busy() == False:
                pygame.mixer.music.load("Sonidos/" + listaMusica[contPos2] + ".mp3")
                pygame.mixer.music.play(1)
        ####CARGA EL PUNTERO PARA LA SELECCION DE PIEZAS####
            if evento.type == KEYDOWN:
                if evento.key == K_DOWN:
                    contPos2 += 1
                    pygame.mixer.music.fadeout(500)
                    pygame.mixer.music.unload()
                    if apuntador.rect.top < (len(listaMusica) - 1) * 50:
                        apuntador.rect.top += 50
                        apuntador.dibujar(ventana)
                    elif apuntador.rect.top >= (len(listaMusica) - 1) * 50:
                        contPos2 = 0
                        apuntador.rect.top = 10
                        apuntador.dibujar(ventana)
                elif evento.key == K_UP:
                    contPos2 -= 1
                    pygame.mixer.music.fadeout(500)
                    pygame.mixer.music.unload()
                    if apuntador.rect.top > 10:
                        apuntador.rect.top -= 50
                        apuntador.dibujar(ventana)
                    elif apuntador.rect.top <= 10:
                        contPos2 = len(listaMusica) - 1
                        apuntador.rect.top = (len(listaMusica) - 1) * 50
                        apuntador.dibujar(ventana)
                elif evento.key == K_SPACE:
                    pygame.mixer.music.rewind()
                    music_select = True
        if evento.type == QUIT:
            pygame.quit()
            sys.exit()
    pygame.display.update()
