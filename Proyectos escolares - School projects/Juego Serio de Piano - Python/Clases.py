import pygame

class Nota(pygame.sprite.Sprite):
    def __init__(self, posX, posY):
        self.imagenNota = pygame.image.load("Assets/Nota.png")
        self.rect = self.imagenNota.get_rect()
        self.velocidad = 1
        self.rect.top = posY
        self.rect.left = posX
        self.listaNotas = []
    def recorrido(self):
        self.rect.top = self.rect.top + self.velocidad
    def dibujar(self, superficie):
        superficie.blit(self.imagenNota, self.rect)

class TeclaD(pygame.sprite.Sprite):
    def __init__(self, posX, posY):
        self.imagenTeclaD = pygame.image.load("Assets/TeclaD.png")
        self.rect = self.imagenTeclaD.get_rect()
        self.rect.top = posY
        self.rect.left = posX
    def dibujar(self, superficie):
        superficie.blit(self.imagenTeclaD, self.rect)

class TeclaF(pygame.sprite.Sprite):
    def __init__(self, posX, posY):
        self.imagenTeclaF = pygame.image.load("Assets/TeclaF.png")
        self.rect = self.imagenTeclaF.get_rect()
        self.rect.top = posY
        self.rect.left = posX
    def dibujar(self, superficie):
        superficie.blit(self.imagenTeclaF, self.rect)

class TeclaG(pygame.sprite.Sprite):
    def __init__(self, posX, posY):
        self.imagenTeclaG = pygame.image.load("Assets/TeclaG.png")
        self.rect = self.imagenTeclaG.get_rect()
        self.rect.top = posY
        self.rect.left = posX
    def dibujar(self, superficie):
        superficie.blit(self.imagenTeclaG, self.rect)

class TeclaH(pygame.sprite.Sprite):
    def __init__(self, posX, posY):
        self.imagenTeclaH = pygame.image.load("Assets/TeclaH.png")
        self.rect = self.imagenTeclaH.get_rect()
        self.rect.top = posY
        self.rect.left = posX
    def dibujar(self, superficie):
        superficie.blit(self.imagenTeclaH, self.rect)

class TeclaJ(pygame.sprite.Sprite):
    def __init__(self, posX, posY):
        self.imagenTeclaJ = pygame.image.load("Assets/TeclaJ.png")
        self.rect = self.imagenTeclaJ.get_rect()
        self.rect.top = posY
        self.rect.left = posX
    def dibujar(self, superficie):
        superficie.blit(self.imagenTeclaJ, self.rect)

class TeclaK(pygame.sprite.Sprite):
    def __init__(self, posX, posY):
        self.imagenTeclaK = pygame.image.load("Assets/TeclaK.png")
        self.rect = self.imagenTeclaK.get_rect()
        self.rect.top = posY
        self.rect.left = posX
    def dibujar(self, superficie):
        superficie.blit(self.imagenTeclaK, self.rect)

class TeclaL(pygame.sprite.Sprite):
    def __init__(self, posX, posY):
        self.imagenTeclaL = pygame.image.load("Assets/TeclaL.png")
        self.rect = self.imagenTeclaL.get_rect()
        self.rect.top = posY
        self.rect.left = posX
    def dibujar(self, superficie):
        superficie.blit(self.imagenTeclaL, self.rect)

class Apuntador(pygame.sprite.Sprite):
    def __init__(self, posX, posY):
        self.imagenApuntador = pygame.image.load("Assets/Apuntador.png")
        self.rect = self.imagenApuntador.get_rect()
        self.rect.top = posY
        self.rect.left = posX
    def dibujar(self, superficie):
        superficie.blit(self.imagenApuntador, self.rect)