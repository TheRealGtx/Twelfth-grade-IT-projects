#Hangman game
from os import system, name

#metodo per pulire la console
def clear():
    if name == 'nt':
        _ = system('cls')

#Regole del gioco
print("Programma di Manzi Giuliano")
print("Benvenuto a questo gioco dell'impiccato! Le regole sono semplici: il giocatore 1 inserisce la parola che il giocatore 2 deve indovinare. Il giocatore 2 cercherà di indovinare la parola andando a tentativi con le lettere. Se il giocatore 2 indovina la parola vince!")

#classe
class impiccato:
    def __init__(self, parolaDaIndovinare, numeroErrori) -> None:
        impiccato.parolaDaIndovinare = parolaDaInDovinare
        impiccato.parolaDaStampare = list(parolaDaInDovinare)
        impiccato.numeroErrori = numeroErrori
    
    def disegno(self):
        match impiccato.numeroErrori:
            case 0:
                print(" _____")
                print("|     |")
                print("|")
                print("|")
                print("|")
                print("________")
            case 1:
                print(" _____")
                print("|     |")
                print("|     0")
                print("|")
                print("|")
                print("________")
            case 2:
                print(" _____")
                print("|     |")
                print("|     0")
                print("|     |")
                print("|")
                print("________")
            case 3:
                print(" _____")
                print("|     |")
                print("|     0")
                print("|    \|")
                print("|    ")
                print("________")
            case 4:
                print(" _____")
                print("|     |")
                print("|     0")
                print("|    \|/")
                print("|    ")
                print("________")
            case 5:
                print(" _____")
                print("|     |")
                print("|     0")
                print("|    \|/")
                print("|    /")
                print("________")
            case 6:
                print(" _____")
                print("|     |")
                print("|     0")
                print("|    \|/")
                print("|    / \\")
                print("________")
                print("Hai perso! La parola era: " + str(parolaDaInDovinare))

        print("Errori: " + str(impiccato.numeroErrori) + "/6")
    
    def maschera(self, lettereParola):
        #inizializza e stampa la parola che apparirà sullo schermo con tanti underscore. Stampa anche il disegno con 0 errori
        i = 1
        while(i < len(lettereParola) - 1):
            match (impiccato.parolaDaStampare[i].capitalize()):
                case 'A':
                    impiccato.parolaDaStampare[i] = '+'
                case 'E':
                    impiccato.parolaDaStampare[i] = '+'
                case 'I':
                    impiccato.parolaDaStampare[i] = '+'
                case 'O':
                    impiccato.parolaDaStampare[i] = '+'
                case 'U':
                    impiccato.parolaDaStampare[i] = '+'
                case _:
                    impiccato.parolaDaStampare[i] = '_'
            i += 1
        return impiccato.parolaDaStampare
    
    def gioco(self, lettera):
        #se viene inserita tutta la parola giusta viene già stampata
        trovata = False
        if(lettera == impiccato.parolaDaIndovinare):
            i = 0
            while(i < len(lettereParola)):
                impiccato.parolaDaStampare[i] = lettereParola[i]
                i += 1
            trovata = True

        i = 0

        #controlla tutte le lettere della parola da indovinare e se la lettera inserita corrisponde viene aggiunta alla parola da stampare
        while(i < len(lettereParola)):
            if(lettera == lettereParola[i]):
                trovata = True
                impiccato.parolaDaStampare[i] = lettera
            i += 1

        #se la lettera non appartiene alla parola il numero di errori aumenta (max 6)
        if(trovata == False):
            impiccato.numeroErrori += 1  

        return impiccato.parolaDaStampare
    
    def controlloFine(self, controllo):
        #arrivati a 6 erori il programma termina

        if(impiccato.numeroErrori == 6):
            intermedio = list(controllo)
            intermedio[1] = True
            intermedio[0] = True
            intermedio[2] = False
            controllo = tuple(intermedio)

        
        #controlla se nella parola con le lettere trovate fino a quel momento rimangono degli underscore. Se non ce ne sono, cioè tutte le lettere sono state indovinate il programma termina
        if("_" not in impiccato.parolaDaStampare and "+" not in impiccato.parolaDaStampare):
            print("Hai indovinato! La parola era " + parolaDaInDovinare + "!")
            intermedio = list(controllo)
            intermedio[1] = True
            intermedio[0] = True
            intermedio[2] = False
            controllo = tuple(intermedio)

        return (controllo)

#main
#0 = rifai, 1 = chiedifine, 2 = gioca, 3 = fineprogramma
controllo = (False, False, True, False)
intermedio = list(controllo) 

while (controllo[3] == False):

    #Input della parola da indovinare
    parolaDaInDovinare = input("Parola da indovinare: ")
    parolaDaInDovinare = parolaDaInDovinare.lower()
    clear()

    #cdc    
    lettereParola = list(parolaDaInDovinare)
    gioco = impiccato(parolaDaInDovinare, 0)

    print(gioco.maschera(parolaDaInDovinare))
    gioco.disegno()

    intermedio[2] = True
    controllo = tuple(intermedio)
    #gioco
    while(controllo[2] == True):
        #input della lettera
        lettera = input("Inserisci una lettera: ")
        lettera = lettera.lower()
        clear()
        
        trovata = False

        #stampa la parola con le lettere indovinate fino a quel momento e il disegno corrispondente al numero di errori
        print(gioco.gioco(lettera))
        gioco.disegno()

        controllo = gioco.controlloFine(controllo)
        while (controllo[0]):
            if (controllo[1] == True):
                scelta = input("Premi S per rigiocare o N per chiudere il programma: ")
                scelta = scelta.capitalize()
                if (scelta == "S"):
                    intermedio = list(controllo)
                    intermedio[2] = False
                    intermedio[3] = False
                    intermedio[0] = False 
                    controllo = tuple(intermedio)
                elif (scelta == "N"):
                    intermedio = list(controllo)
                    intermedio[2] = False
                    intermedio[3] = True
                    intermedio[0] = False
                    controllo = tuple(intermedio)
                else:
                    print("Inserisci un valore valido")
                    intermedio = list(controllo)
                    intermedio[1] = True
                    controllo = tuple(intermedio)


#fine programma
print("Premi invio per terminare il programma")
input()