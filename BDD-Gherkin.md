# Gherkinit 

## Feature: Vapaan ajan tarkistaminen.
Käyttäjänä haluan tarkistaa vapaita aikoja, jotta voin päättää mitä varata.
 
**1.Scenario** Vapaan ajan tarkistaminen.
**Given** Käyttäjä ei ole vielä sivulla/sovelluksessa. 
**When** Käyttäjä avaa sivun/sovelluksen.
**Then** Käyttäjä näkee vapaat varattavat ajat


 ## Feature: Varauksen luominen.
 
Käyttäjänä haluan varataa minulle sopivan ajan.

**1-Scenario**Luo onnistunut varaus käytettävissä olevan ajan puitteissa
 **Given** Varauksia voi tehdä koko päivän.
 **And** Ei varauksia tänään
 **When** Asiakas katsoi ajat ja valitsi sopivan ajan
 **Then** Varaus hyväksytään ja tallennetaan varauslistaan.

**2-Scenario**Varaus epäonnistui olemassa olevan varauksen vuoksi
 **Given** Samalle päivämäärälle on olemassa oleva varaus.
 **When** Yritän varata ajan samaan aikaan, kun toinen asiakas varasi palvelun.
 **Then** Varaus hylätään ja asiakkaalle ilmoitetaan päällekkäisyydestä.

 **3-Scenario**Varaus epäonnistuu palvelun saatavuuden vuoksi
 **Given** Valittu aika on virallisen työajan ulkopuolella.
 **When** Yritetään varata aika samaan aikaan virallisen työajan ulkopuolella.
 **Then**  Varaus hylätään ja asiakkaalle ilmoitetaan viikon aikana noudatettavat aukioloaika.

 **4-Scenario**Varaus epäonnistui osittaisen päällekkäisyyden vuoksi
 **Given** Ajanvaraus on olemassa klo 12.00–13.00 10.3.2026.
 **When** asiakas yrittää varata ajan klo 12.30–13.30,
 **Then** varaus hylätään.Syynä on päällekkäisyys toisen varauksen kanssa.

 
## Feature: Varauksen peruminen

Käyttäjänä haluan perua minun jo varaamani ajan.

 **1-Scenario**Peruuta olemassa oleva varaus
 **Given** Ajanvaraus on olemassa klo 15.00–16.00 10.3.2026.
 **When** asiakas pyytää peruutusta
 **Then**  Varaus poistetaan järjestelmästä.
 **And** aika on jälleen varattavissa.
