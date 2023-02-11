# IT FELT SURREAL

IT Felt Surreal è un progetto che consiste nello sviluppo di un'ambientazione per giochi horror (l'interno di una scuola in orario notturno) della tipologia escape room.
La scuola è costituita da quattro ambienti:
- Corridoio
- Aula
- Bagno
- Infermeria

Il giocatore ha la possibilità di interagire con gli oggetti di scena, al fine di risolvere diversi enigmi all'interno di ciascun ambiente. Alcuni di questi oggetti sono, per esempio:
- chiavi
- lucchetti di varia tipologia (con chiave, con combinazione, ...)
- orologio a muro che permette di gestire il ciclo giorno-notte
- specchio "dimensionale"
- indizi e bigliettini zoomabili
- porta "portale"

Il giocatore dispone di un inventario nel quale colleziona gli oggetti presenti nella scuola, dei quali si serve per sbloccare le porte delle stanze.

## Geometria non euclidea
All'interno delle scene è possibile osservare fenomeni bizzarri, anormali, che permettono di ricreare un ambiente distorto e cupo, peculiare per i giochi horror. Questi fenomeni sono stati creati sfruttando i **principi della geometria non euclidea**; in particolare sono stati utilizzati per realizzare:
- corridoio infinito: il giocatore continua a camminare in una direzione all'infinito, ma voltandosi scopre di rimanere sempre nello stesso punto;
- scale infinite: come il corridoio, ma il piano di partenza e il piano di arrivo del giocatore coincidono;
- "bagno teletrasporto": il giocatore, entrando all'interno di un particolare bagno, viene catapultato in un'altra dimensione, nella versione distorta del bagno stesso;
- "specchio dimensionale": all'interno della copia distorta del bagno c'è uno specchio che permette di osservare ciò che accade nella dimensione originale

## Modifica degli asset
Molti degli asset utilizzati non  erano adatti all'ambientazione (per esempio, il corridoio era una scena fine a se stessa e non permetteva la visione dell'interno delle aule) e tutti gli asset contenenti scritte erano in giapponese.
Utilizzando GIMP e Blender sono stati realizzati i seguenti punti:
- Apertura delle stanze del corridoio
- Traduzione delle scritte sugli asset
- Modifica della mano che regge lo smartphone
- Modifica delle porte nel corridoio

## Gestione delle luci
Per rendere più realistica l'ambientazione sono stati aggiunti e gestiti i volumi nelle scene per regolare effetti visivi come il bloom, il motion blur, la vignettatura, etc... e gli shaders per regolare la riflessione e la rifrazione della luce su diversi materials (sulle maioliche del bagno, per esempio, la luce viene riflessa per ricreare un ambiente umido, viceversa sui muri delle altre stanze non c'è riflesso).

## Impostazioni grafiche
Per migliorare l'esperienza utente è stato aggiunto un meccanismo per gestire le impostazioni grafiche. Di seguito l'elenco delle impostazioni configurabili:
- livello della grafica
- risoluzione
- fullscreen
- vsync
- anti-aliasing
- motion blur
- bloom

E' stata aggiunta la "modalità per daltonici", pensata per garantire maggiore accessibilità. Questa modalità fornisce nove effetti diversi:
- normale
- protanomalia
- protanopia
- deuteranopia
- deuteranomalia
- tritanopia
- tritanomalia
- acromatopsia
- acromatomalia

## Salvataggio

E' stato introdotto un meccanismo per il salvataggio dei progressi di gioco e delle impostazioni che permette di creare una nuova partita oppure di continuare quella già avviata, senza dover settare nuovamente tutte le impostazioni.

## Tecnologie
- Unity: Game Engine
- C#: per gestire la logica di gioco
- Blender: modifica degli asset
- Gimp: per modifica delle texture
- Git: version control system


