# URP_Workshop2

De volgende tekst bevat het stappenplan om het Unity-project te verbeteren. Er zijn namelijk problemen met onderdelen van URP, voornamelijk: 
- URP-asset
- Performance
- Verlichting
- Shaders

Bij elke stap staat hoelang het zou moeten duren. Als je de tijd niet haalt, kan je voor elke overkoepelende stap een nieuwe branch inladen om naar die specifieke stap te gaan. 
Succes en veel plezier met renderen!

## Het licht aanzetten (5 minuten)
Als je de scene inlaad, zie je als het goed is een vreemd zwart object in de scene zweven. Dit is een grot waar de speler in staat, het is helaas nog compleet donker. 
- Voeg de juiste light type toe aan de torch zodat de player zijn omgeving kan zien. 
- Zorg er ook voor dat er licht vanuit boven op de fontein schijnt. Alleen de fontein moet belicht zijn, dus gebruik de juiste light type. Dit is van belang voor de volgende stappen.

## Een goede framerate (8 minuten)
Het spel kan mogelijk wat laggy aanvoelen, vooral als je midden in de grot aan het rondkijken bent. Het is op verschillende manieren mogelijk om erachter te komen wat er voor deze lag zorgt. Voor nu zullen we de profiler gebruiken. Open de profiler door op Window>Analysis>Profiler te klikken. Als je het spel aanzet terwijl de profiler open staat zal je een analyse van de framerate zien. Als je op een willekeurig tijdstip op de timeline klikt (de grote groene grafiek) zal je als het goed is het volgende zien: 

![image](https://github.com/user-attachments/assets/d35660c5-42c4-4442-aefd-29d129b99d14)


De profiler heeft een paar belangrijke onderdelen. Onderdelen van de profiler worden hieronder genummerd en uitgelegd: 

![image](https://github.com/user-attachments/assets/89d686b9-9f3e-4246-8ced-a450b01bb1cc)

1. Via deze drop down kan je profiler modules aan of uit zetten die dan aan de linker kant van de profiler weergeven worden. 
2. Via deze drop down kan je de target frame rate zetten. De profiler zal dan checken of het spel aan deze framerate voldoet tijdens het testen. 
3. Dit is een timeline waar getoond wordt of de CPU en GPU de framerate halen. Als je op een punt op deze timeline klikt zal je onderin het scherm een berekening zien van de CPU en GPU times. 

![image](https://github.com/user-attachments/assets/78f5e834-20c3-475f-ad2e-8adceca6a4ce)

4. Dit zijn de modules met legenda om te zien welk onderdeel gelinkt is aan de timeline. 
5. Dit is de timeline waarin wordt bijgehouden hoeveel fps elke module (en daaronder elk deel van de module) heeft. 

![image](https://github.com/user-attachments/assets/3a81e2a3-1559-417a-b6c4-37af04bce302)

6. Hier staan de opties voor de detail view. Hierdoor kan je in verschillende manieren zien hoe de verdeling van processing tijd verdeelt is over verschillende processen/functies. 
7. Hier staat een gedetailleerde view van hoeveel processing tijd elk process/functie erover doet en in welke volgorde die het doet gebaseerd op de huidig geselecteerde frame.

Nu je snapt hoe de profiler in elkaar steekt, kan je proberen de volgende opdracht uit te voeren: 
Er is een gameobject die voor veel lag zorgt. Vind dit object en verwijder het. Tip: Zet elk gameobject uit totdat de performance dramatisch verbeterd. Zie het figuur hieronder hoe het er als het goed is uitziet als het gameobject wordt uitgezet. 

![image](https://github.com/user-attachments/assets/38acaf44-bcd4-43af-8fd3-28268403b497)


### Static batching
Houd er wel rekening mee dat dit niet de standaard manier is waarop de profiler gebruikt wordt, maar dat deze opdracht bedoeld is om je bekend te laten worden met de profiler. Gewoonlijk wordt de profiler gebruikt om te zien waar de bottleneck in je spel zit (bijvoorbeeld op CPU, GPU en rendering calls). Als je bijvoorbeeld zou zien dat de renderer veel tijd inneemt, zou je verschillende aanpassingen kunnen maken aan het project om de rendering te verbeteren. Eén optie om dat te doen is static batching. In de volgende stappen gaan we proberen static batching aan te zetten en zullen we in de profiler een verbetering zien van de rendering performance. 

Om static batching te gebruiken, moet je als eerst static batching aanzetten in het project. (zie figuur ???)

![image](https://github.com/user-attachments/assets/08a91695-37b4-4eb2-9a2d-03433709e756)

Om gebruik te maken van static batches, moet je wel static objecten maken. Op het moment zijn er nog geen static objecten. Maak de cave, toadstools en fountain static. 

![image](https://github.com/user-attachments/assets/c611ce56-48d8-4e6e-bdb9-815a369eab9e)

Zet het spel aan en kijk naar de profiler. Klik op de Rendering module aan de linker kant van de profiler. Onderin het scherm zal je een lijst met informatie zien. Merk op dat de draw calls en batches ruim verminderd worden als je static batching aan hebt staan. Om goed het veschil te zien, run de scene met static batching aan en zet het vervolgens weer uit via de project settings. 

![image](https://github.com/user-attachments/assets/9d06ac43-f9e2-4ee0-94e7-234cc0693967)

## Het stinkende water schoonmaken.

Zoals je ziet is het water stinkend en groen. Maak deze weer blauw door gebruik van de shader graph. Ook staat het water stil voeg beweging zoals kleine golfjes toe aan het water. Gebruik de volgende nodes:

## Fairies Introduceren

Op dit moment zijn er geen feeën rond de fontein, omdat het water stinkt. De opdracht is om de VFX Graph te gebruiken om de "stinkende" deeltjes te transformeren in feeën die rond de fontein vliegen.  

#### Requirements  

- De stinkende deeltjes moeten een gele of blauwe kleur krijgen.  
- Feeën moeten rond de fontein draaien met behulp van een **Rotate 3D**-node.  
- De **spawnlocatie** van de feeën moet willekeurig zijn om een natuurlijke verspreiding te creëren. Dit bepaalt ook de spawnradius.  
- De positie van de feeën moet in het **Update Particle**-blok worden aangepast, zodat ze rond de fontein blijven bewegen.  

## Post processing

Om de scene wat minder plat en eentonig te maken kan je post processing effecten toe te voegen. Je kan dit doen door de default volume aan te passen, of een golbal volume aan te maken en hier overrides in aan te geven.
De default volume heeft alle post processing effecten tot zijn beschikking en ziet er als volgt uit:

![image](https://github.com/user-attachments/assets/e71358bf-b27c-4cea-b838-fc384c774373)

Een global volume kan je als GameObject aan je scene toevoegen, in de inspector kan je hier een volume profile voor aanmaken. Vervolgens kan je hier overrides aan toe voegen voor de post processing onderdelen die je wilt aanpassen. Gebruik dit om je scene er zo mooi mogelijk uit te laten zien.

![image](https://github.com/user-attachments/assets/5ace08d9-223e-43ec-8704-b5bc4bbf773a)





## De asset verbeteren (8 minuten)
TODO: Laat ze met render scale kloten en maak een aparte scene voor LOD. 
