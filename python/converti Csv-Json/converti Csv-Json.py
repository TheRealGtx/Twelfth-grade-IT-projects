#Reads the .csv files and writes the values in a .json file
fcsv = open('Persone.CSV', 'r')
fjson = open('Persone.JSON', 'w')
line = fcsv.readline()
fjson.write("[\n")
while (line):
    fjson.write("   {\n")
    line = line.strip()
    print(line)
    campi = line.split(";")
    print(campi)
    fjson.write('   "Nome": "'+campi[0]+'",\n')
    fjson.write('   "Cognome": "'+campi[1]+'",\n')
    fjson.write('   "Altezza": '+campi[2]+',\n')
    fjson.write('   "Peso": '+campi[3]+'\n')
    fjson.write("   }\n")

    line = fcsv.readline()
    if line:
        fjson.write("   ,\n")

fjson.write("]\n")

print()
fcsv.close()
fjson.close()