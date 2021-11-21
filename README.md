# Tolkien API

Zvaničan LOTR API:
- http://lotr.wikia.com/api.php

Otvaranje članka po id-u:
- http://lotr.wikia.com/?curid=27

## TODO

- ne vracati null polja
- da bude qoute.Author
- povezati slike sa https://lotr.wikia.com/ ili http://www.tolkiengateway.net/

## Model

Character

  name 410
  text 410
  gender 410
  lotr_page_id 410
  race 410

  birth 340
  culture 387 +
  death 325
  eyes 63
  hair_color 240
  height 76
  location 165 +
  other_names 287
  rule 101
  spouse 105 +
  titles 317
  weapon 216

Race

  name 23
  locations 23 ++
  distinctions 23
  text 23
  lotr_page_id 23

  characters 21 ++
  hair_color 8
  height 16
  languages 16
  lifespan 12
  origins 11
  other_names 13
  skin_color 13

Culture

  name 97
  text 97
  lotr_page_id 97

  characters 48 ++
  distinctions 27
  hair_color 19
  height 26
  languages 45
  lifespan 40
  locations 55 ++
  origins 27
  other_names 30
  skin_color 24

Location

  name 449
  text 449
  lotr_page_id 449

  capital 30
  cultures 212 ++
  description 191
  events 81
  founded_or_built 85
  governance 98
  lifespan 100
  major_towns 34
  other_names 128
  position 252
  regions 81
  type 241

Battle

  name 82
  lotr_page_id 82
  location 82 +
  text 82

  conflict 44
  date 43
  outcome 44

Artefact

  name 50
  lotr_page_id 50
  text 50
  character 50 +

  appearance 13
  location 14 +
  other_names 9
  usage 9

Quote

  text 50
  character 50 +
  source 50

## Fale

- Kulture:
  'Elves of Rivendell',
  'Ents of Fangorn Forest',
  'Hobbits of the Shire',
  'Orcs of Morgoth',
  'Orcs of the Misty Mountains',
  'Dwarves of the Blue Mountains'

- Karakteri:
  'Elladan', 'Elrohir'
  'Fíli', 'Kíli', 'Orophin', 'Rúmil', 'Ulfast' 