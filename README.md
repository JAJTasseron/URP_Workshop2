# URP_Workshop2

De volgende tekst bevat het stappenplan om het Unity-project te verbeteren. Er zijn namelijk problemen met onderdelen van URP, voornamelijk: 
- URP-asset
- Performance
- Verlichting
- Shaders

Bij elke stap staat hoelang het zou moeten duren. Als je de tijd niet haalt, kan je voor elke overkoepelende stap een nieuwe branch inladen om naar die specifieke stap te gaan. 
Succes en veel plezier met renderen!

## Het licht aanzetten (8 minuten)
Als je de scene inlaad, zie je als het goed is een vreemd zwart object in de scene zweven. Dit is een grot waar de speler in staat, het is helaas nog compleet donker. Voeg een point light toe op de coördinaten ... zodat de speler zijn omgeving kan zien. 

## De asset verbeteren (8 minuten)
Als de speler om zich heen kijkt, kan die helaas nog geen mooie omgeving zien. Kijk

## Een goede framerate (8 minuten)
Het spel kan mogelijk wat laggy aanvoelen, vooral als je midden in de grot aan het rondkijken bent. Het is op verschillende manieren mogelijk om erachter te komen wat er voor deze lag zorgt. Voor nu zullen we de profiler gebruiken. 

Houd er wel rekening mee dat dit niet de standaard manier is waarop de profiler gebruikt wordt, maar dat deze opdracht bedoeld is om je bekend te laten worden met de profiler. Gewoonlijk wordt de profiler gebruikt om te zien waar de bottleneck in je spel zit (bijvoorbeeld op CPU, GPU en rendering calls). Als je bijvoorbeeld zou zien dat de renderer veel tijd inneemt, zou je verschillende aanpassingen kunnen maken aan het project om de rendering te verbeteren. Eén optie om dat te doen is static batching. In de volgende stappen gaan we proberen static batching aan te zetten en zullen we in de profiler een verbetering zien van de rendering performance. 

![image](https://github.com/user-attachments/assets/38acaf44-bcd4-43af-8fd3-28268403b497)

Om static batching te gebruiken, moet je als eerst static batching aanzetten in het project. (zie figuur ???)

![image](https://github.com/user-attachments/assets/08a91695-37b4-4eb2-9a2d-03433709e756)

Om gebruik te maken van static batches, moet je wel static objecten maken. Op het moment zijn er nog geen static objecten. Maak de cave, toadstools en fountain static. 

![image](https://github.com/user-attachments/assets/c611ce56-48d8-4e6e-bdb9-815a369eab9e)

Zet het spel aan en kijk naar de profiler. Klik op de Rendering module aan de linker kant van de profiler. Onderin het scherm zal je een lijst met informatie zien. Merk op dat de draw calls en batches ruim verminderd worden als je static batching aan hebt staan. Om goed het veschil te zien, run de scene met static batching aan en zet het vervolgens weer uit via de project settings. 

![image](https://github.com/user-attachments/assets/9d06ac43-f9e2-4ee0-94e7-234cc0693967)


## Stap ???
