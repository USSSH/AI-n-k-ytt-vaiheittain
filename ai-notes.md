# AI Notes

Tekoälylle annettut promtit sekä tiivistelmä mitä tekoäly antoi vastaukseksi sekä kuinka se toimi.

## 1. Konsoli Sovelluksen alustus
*Älä luo mitään ylimääräistä mitä ei pyydetä. Aloitetaan tekemällä C# konsoli sovellus.*

```
- Created C# Console application workspace.  
- using "Create New Workspace"  
- Getting setup information  
- Created C# Program.cs  
- Created ConsoleApp.csproj  
```

Tämä prompti toimi hyvin ja loi pohjan konsolisovellukselle kuten piti.

## 2. Valikon luominen

*Tee konsoli sovellukseen valikko jossa on valinnat 1. Vapaat ajat 2. Varaa aika 3. Peru aika X. Lopeta. Älä tee mitään muuta.*

```
Read Program.cs file
Edited C# Program.cs +30 -1
```

Tämä prompti toimi hyvin.
- Poisti *Hello World!*
- Lisäsi Valikon Swtich-case käyttäen

Ehkä lisäsi hieman ylimääräisiä pieniä asioita kuten:
- Teksti *Ohjelma päätetään* kun käyttäjä valitsee X.
Ei kuitenkaan mitään suurta.

## 3. Varaa aika methodi

*Tee methodi varaa aika: Käyttäjälle kerrotaan mikä päivänmäärä tänään on ja kerrotaan, että mikäli hän haluaa palata edelliseen valikkoon hän kirjoittaa B ja mikäli hän haluaa lopettaa hän kirjoittaa X ja painaa enteriä. Käyttäjältä kysytään päivänmäärää jolloin hän haluaa varata ajan. Seuraavaksi käyttäjältä kysytään alkamiskellon aika ja sitten päättymiskellon aika. Varatut ajat lisätän varatut ajat listalle.*

```
- Edited C# Program.cs +44 -1
```

Prompti toimi hyvin ja tekoäly loi mitä pyydettiin.

### If Lause viikonloppujen kiinniolon vuoksi

*Lisätään if lause mikäli käyttäjä yrittää valita päivänmäärän mikä on viikonpäivänä lauantai tai sunnuntai. Virhe ilmoituksessa kerrotaan, että liike ei ole auki lauantaina eikä sunnuntaina. Liike on auki vain arkisin 08.00 - 16.00*

```
- Lisään validoinnit päivänmäärälle ja ajoille (vain arkisin 08:00 - 16:00, ei lauantai/sunnuntai).
```

Tässäkin tapauksessa prompti toimi hyvin. Tekoäly tosin lisäsi koodin myös seuraavan if lauseen ilman, että sitä laittoi sinne itse. Eli hieman toimi yli pyydetyn.  
Olisi pitänyt varmistaa, että ei tee näin.


