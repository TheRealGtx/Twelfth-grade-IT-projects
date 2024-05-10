#Given the list dimension, it gets populated with random values and then some operations are made on it.
import random

def inizializzaLista(dimensione):
    lista = []
    for i in range(dimensione):
        lista.append(random.randrange(1, 10))
    return lista

def ordinaLista(lista):
    lista.sort()
    return lista

def trovaMedia(lista):
    somma = 0
    for i in lista:
        somma += lista[i]
        media = somma/len(lista)
    return media

def trovaMediana(lista, dimensione):
    mediana = (lista[0] + lista[dimensione - 1])/2
    return mediana

def trovaModa(lista):
    #da fare
    pass
        
dimensione = int(input("inserisci la dimensione della lista: "))
lista = inizializzaLista(dimensione)
print("Lista: " + str(lista))
lista = ordinaLista(lista)
print("Lista ordinata: " + str(lista))
print("Media dei numeri nella lista: {0}".format(trovaMedia(lista)))
print("Mediana dei numeri nella lista: {0}".format(trovaMediana(lista, dimensione)))