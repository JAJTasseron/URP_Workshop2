# URP | Antwoorden

## Licht Aanzetten

-	De juiste light type voor de torch is de point light. Point light geeft licht aan alle kanten vanuit de torch.
-	Particles..


## Een Goede Framerate
-	Om het gameobject te vinden moet je elk gameobject in de hyrarchy uitzetten via de inspector totdat de lag afneemt. Als het goed is zal je in de profiler kunnen zien wanneer de lag dramatisch afneemt. 
-	Het gameobject wat voor deze lag zorgt is de particle generator verstopt in: Cave_Toadstools>Toadstools2>Toadstools1>Strange_Mushroom. 

![image](https://github.com/user-attachments/assets/2817109b-df30-45cc-b094-e1bcac8894c4)

## Shader Graph | Water

## VFX
1. Om de kleur te veranderen naar geel moet de "set color" blok aangepast worden alsvolgt:
![Color image](images/Color%20Image.png)
2. Om de feeën te laten vliegen rond de fontein te vliegen moet de VFX graph er alsvolgd uitzien:
![flying image](images/VFXGraph.png)
De "set position shape" blok moet verwijderd worden 
## Global Effects
