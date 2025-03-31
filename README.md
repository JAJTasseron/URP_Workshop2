# URP_Workshop2

De volgende tekst bevat het stappenplan om het Unity-project te verbeteren. Er zijn namelijk problemen met onderdelen van URP, voornamelijk: 
- URP-asset
- Performance
- Verlichting
- Shaders

Bij elke stap staat hoelang het zou moeten duren. Als je de tijd niet haalt, kan je voor elke overkoepelende stap een nieuwe branch inladen om naar die specifieke stap te gaan. 
Succes en veel plezier met renderen!

## Stap 1 | Het licht aanzetten (5 minuten)
Als je de scene inlaad, zie je als het goed is een vreemd zwart object in de scene zweven. Dit is een grot waar de speler in staat, het is helaas nog compleet donker. 
- Voeg de juiste light type toe aan de torch zodat de player zijn omgeving kan zien. 
- Zorg er ook voor dat er licht vanuit boven op de fontein schijnt. Alleen de fontein moet belicht zijn, dus gebruik de juiste light type. Dit is van belang voor de volgende stappen.

## Stap 2 | Een goede framerate (8 minuten)
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


## Stap 3 | Het stinkende water schoonmaken (Shader graph)

Zoals je ziet is het water stinkend en groen. De stinkende particles gaan we omtoveren naar fairies bij de VFX graph, deze hoef je voor dit onderdeel dus niet aan te passen. Wel gaan we hier alvast het groene water naar een blauwe kleur toveren doormiddel van de shader graph. Bestudeer de water shader graph. Deze kun je openen door te dubbel klikken op WaterShader helemaal rechts.

![image](https://github.com/user-attachments/assets/a0eb8e9c-658e-4487-a26f-db41e2c5a46f)

De shader graph

![image](https://github.com/user-attachments/assets/9223b8af-9d69-45c1-9c39-f005bee2334f)


Hier boven zie je het deel waar de kleur van het water wordt ingesteld. Links kunnen we inputvalues aanmaken en deze aan nodes hangen. Deze zijn vervolgens instelbaar vanuit de scene view. Klik op het water in de fontein of op fountain_water in de hierarchy. Als het goed is kan je in de inspector nu de verschillende inputs zien van de surface(het water)

![image](https://github.com/user-attachments/assets/5ea225a4-131f-4726-ae6f-0517619109d0)


Zoals te zien in de shader graph heeft het water nu alleen groen shallowWater die aansluit op a en b van de node. Verwijder de connectie van shallowWater naar de b input van de node en voeg een deepWater value toe en hang deze aan de b input van de lerp node. Pas de kleuren aan van shallowWater en deepWater naar lichtblauw en donker blauw(vergeet bij niet de alpha value in te stellen(195 voor lichtblauw en 220 voor donkerblauw).  Deze lerp node in combinatie met de input field depth zorgt ervoor dat de kleuren verschillen op basis van diepte van het water. Dit gebeurt links in de shadergraph bij depth. De water kleur veranderd bij de randen en in het midden dichtbij het steen van de fontein. Hoe dichter bij de randen of hoe ondieper het water hoe lichter het water wordt. Vanaf hoe ondiep dit gebeurd is in te stellen met de depth input value. Voor nu is 0.1 goed.

![image](https://github.com/user-attachments/assets/5f655f5e-d662-43ce-8a4b-f2ee1dce2348)
Zoals je misschien al is opgevallen hangt deze lerp node aan de fragment base color(om de kleur aan te passen) en via een split node aan de aan de alpha value(om de transparantie van de kleur aan te passen. 

Voor de volgende stap passen we niet de fragment aan maar aan de vertex.


(Advanced) Ook staat het water stil voeg beweging zoals kleine golfjes toe aan het water. Je kan nodes toevoegen door op spatie te drukken in de shader graph vervolgens kan je zoeken in de zoekbalk.

Tip doe dit boven in in de buurt van de vertex.

Voeg de volgende nodes toe en connect ze op de volgende wijze. Nodes worden aangegeven met () en de value van een node met de binnenste haakjes.

(time(time1)) -> (divide(A1)) zet x van b op 100. (divide(Out1)) -> (Tiling and Offset(Offset2)) zet de tiling x en y op 1.  (Tiling and Offset(out2)) -> (Gradient Noise(UV2)) zet de x op 20.  
(Gradient Noise(UV2)) -> (Multiply(B1)) voeg een input value genaamd Displacement toe aan de a van de Multiply node.

Maak nu een nieuwe chain van nodes.

begin met position en zet de space op Object ipv world.
(Position(Out3)) -> (Split(In3)).  (Split(R1)) -> (Combine(R1)) en (Split(B1)) -> (Combine(B1)) (connect de split r1 en b1 naar dezelfde combine node.) 

Vervolgens kunnen we de Multiply node van de eerste chain ook connecten aan de Combine node deze doen we op (Multiply(out1) -> (Combine(G1)).

Connect de Combine node out nu aan de vertex Position(3).

Je kan in de de scene inspector bij surface inputs de displacement aanpassen. Deze value stelt de intensiteit van de golven in. Zet deze op 0.3.

Als het goed is heb je nu golvend water :')


## Stap 4 | Fairies Introduceren

Op dit moment zijn er geen feeën rond de fontein, omdat het water stinkt. De opdracht is om de VFX Graph te gebruiken om de "stinkende" deeltjes te transformeren in feeën die rond de fontein vliegen.  

#### Requirements  

- De stinkende deeltjes moeten een gele of blauwe kleur krijgen.  
- Gebruik de **Set position** blok in de **update particles** node om de posititie te veranderen i.p.v **Set velocity**. 
- Feeën moeten rond de fontein draaien met behulp van een **Rotate 3D**-node.  
- Gebruik de **Total Time (VFX)**-node om de hoek te bepalen.
- De **spawnlocatie** van de feeën moet willekeurig via de **Random Vector3** node zijn om een natuurlijke verspreiding te creëren. 
- De radius wordt bepaald met de **Radius**-property
- De positie van de feeën moet in het **Update Particle**-blok worden aangepast, zodat ze rond de fontein blijven bewegen.  

#### Optioneel
- Zorg dat de feeën op en neer gaan in een vloeinende golf
- Zorg dat de groote van de golf aangepast kan worden in de inspector


## Stap 5 | Post processing

Om de scene wat minder plat en eentonig te maken kan je post processing effecten toe te voegen. Je kan dit doen door de default volume aan te passen, of een golbal volume aan te maken en hier overrides in aan te geven.
De default volume heeft alle post processing effecten tot zijn beschikking en ziet er als volgt uit:

![image](https://github.com/user-attachments/assets/e71358bf-b27c-4cea-b838-fc384c774373)

Een global volume kan je als GameObject aan je scene toevoegen, in de inspector kan je hier een volume profile voor aanmaken. Vervolgens kan je hier overrides aan toe voegen voor de post processing onderdelen die je wilt aanpassen. Gebruik dit om je scene er zo mooi mogelijk uit te laten zien.

![image](https://github.com/user-attachments/assets/5ace08d9-223e-43ec-8704-b5bc4bbf773a)

## Extra stap | LOD's (5 minuten)

Requirement:
- Ga naar LODScene.

Om er voor te zorgen dat een object niet op hoge kwaliteit gerendered blijft als de camera er verder van af gaat, maken wij gebruik van de Level of Detail component (LOD). 
Op de plane is een boom geplaatst waarvan de kwaliteit omlaag gaat als de camera er verder vanaf gaat. 

Zorg er voor dat de transition tussen de LOD's sneller zijn, zodat je verschil tussen de kwaliteit sneller kan zien.


## De asset verbeteren (8 minuten)
TODO: Laat ze met render scale kloten en maak een aparte scene voor LOD. 
