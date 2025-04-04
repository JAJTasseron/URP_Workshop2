# URP_Workshop2

De volgende tekst bevat het stappenplan om het Unity-project te verbeteren. Er zijn namelijk problemen met onderdelen van URP, voornamelijk: 
- Performance
- Verlichting
- Shaders

Bij elke stap staat hoelang het zou moeten duren. Als je de tijd niet haalt, kan je voor elke overkoepelende stap een nieuwe branch inladen om naar die specifieke stap te gaan. 
Succes en veel plezier met renderen!

## Stap 1 | Het licht aanzetten (5 minuten)
Als je de scene inlaad, zie je als het goed is een vreemd zwart object in de scene zweven. Dit is een grot waar de speler in staat, het is helaas nog compleet donker. 
- Voeg de juiste light type toe aan de torch zodat de player zijn omgeving kan zien. 
- Zorg er ook voor dat er licht vanuit boven op de fontein schijnt. Alleen de fontein moet belicht zijn, dus gebruik de juiste light type. Dit is van belang voor de volgende stappen.

## Stap 2 | Een goede framerate (15 minuten)
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



# Stap 3 | Het stinkende water schoonmaken (Shader Graph) (25min)

Het water in de fontein ziet er momenteel stinkend en groen uit. De stinkende particles worden in een later stadium omgetoverd naar feeën via de VFX Graph, dus hier hoef je niets aan te passen. In deze stap focussen we ons op het aanpassen van de waterkleur van stinkend groen naar blauw met behulp van de Shader Graph.

## Water Shader Graph openen

Om de Shader Graph van het water te openen:
1. Dubbelklik op **WaterShader** aan de rechterkant.

### Shader Graph overzicht

![Shader Graph](https://github.com/user-attachments/assets/a0eb8e9c-658e-4487-a26f-db41e2c5a46f)

Hierboven zie je het gedeelte waarin de kleur van het water wordt ingesteld. Links kunnen we inputwaarden aanmaken en deze koppelen aan nodes. Deze waarden zijn vervolgens instelbaar vanuit de **Scene View**.

### Waterkleur aanpassen

1. Klik op het water in de fontein of op **fountain_water** in de **Hierarchy**.
2. In de **Inspector** zie je nu de verschillende inputwaarden van de surface (het water).

![Inspector](https://github.com/user-attachments/assets/5ea225a4-131f-4726-ae6f-0517619109d0)

3. In de Shader Graph zie je dat het water alleen een **shallowWater** kleur gebruikt die gekoppeld is aan **A** en **B** van de node.
4. Pas de volgende wijzigingen toe:
   - **Verwijder** de connectie van **shallowWater** naar de **B input** van de node.
   - **Voeg een nieuwe waarde toe:** **deepWater**.
   - **Verbind** deze waarde met de **B input** van de **Lerp node**.
   - **Stel de kleuren in:** vergeet niet deze een Alpha value mee te geven anders is de kleur doorzichtig. Ik heb er een suggestie bij gezet.
     - **ShallowWater:** Lichtblauw  (Alpha: 195)
     - **DeepWater:** Donkerblauw  (Alpha: 220)

De **Lerp node** werkt samen met de **Depth input value** om de kleuren te variëren op basis van de diepte van het water. Dit zorgt ervoor dat:
- Het water bij de randen lichter is.
- Het water dieper in de fontein donkerder wordt.
- De diepte waar deze overgang plaatsvindt wordt bepaald door de **Depth input value** (voor nu zetten we deze op : **0.1**).

![Depth instellingen](https://github.com/user-attachments/assets/5f655f5e-d662-43ce-8a4b-f2ee1dce2348)

> **Let op:** De Lerp node is verbonden met de **Fragment Base Color** (voor kleur) en via een **Split node** met de **Alpha value** (voor transparantie).

## (Advanced) Waterbeweging toevoegen

Het water staat momenteel stil. We voegen nu kleine golfjes toe. Je kunt nodes toevoegen in de Shader Graph door op **Spatie** te drukken en de juiste nodes te zoeken.

### Stappenplan:

1. Voeg de volgende nodes toe en verbind ze zoals hieronder:
   
   **Eerste chain van nodes (tijd en offset berekening):**
   - `(Time(Time1))` → `(Divide(A1))` (zet X van B op **100**).
   - `(Divide(Out1))` → `(Tiling and Offset(Offset2))` (zet Tiling X en Y op **1**).
   - `(Tiling and Offset(Out2))` → `(Gradient Noise(UV2))` (zet X op **20**).
   - `(Gradient Noise(UV2))` → `(Multiply(B1))`.
   - Voeg een **input value** genaamd **Displacement** toe en verbind deze met **A van de Multiply node**.

2. Maak een nieuwe chain van nodes:
   - Begin met `(Position)` en zet **Space op Object** (in plaats van World).
   - `(Position(Out3))` → `(Split(In3))`.
   - `(Split(R1))` → `(Combine(R1))`.
   - `(Split(B1))` → `(Combine(B1))`.
   - Verbind de **Multiply node uit de eerste keten** met `(Combine(G1))`.
   - `(Combine(Out))` → **Vertex Position (3)**.

3. Pas de golvenintensiteit aan:
   - Ga in de **Scene Inspector** naar **Surface Inputs** en pas de **Displacement** waarde aan.
   - Zet **Displacement op 0.3**.

4.  Waarschijnlijk is door het aanpassen van de displacement het water nu te laag om te zien. Controleer de transform van het water:
   - Klik op het water in de fontein of op **fountain_water** in de **Hierarchy**.
   - Waarschijnlijk staat de **Z-transform** nu op **-0.105**. 
   - Zet deze op ongeveer **0.26** zodat het water zichtbaar blijft.

 **Als alles goed is gegaan, heb je nu golvend water!** 🎉🎉




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

