INCLUDE globals.ink

{ liho_banished:-> end_dialogue}
{ mari_met:-> meet }
-> first_meet


=== first_meet ===
~mari_met = true
Добрый вечер, Фёдор, я вас заждалась, все люди уже разошлись.#author:mari
Впрочем неважно, вы же разберётесь с дьяволом?#author:mari
* Да, я собрал всё необходимое#author:fedor
- Вот ключи от подвала, избавьте меня от этого демона поскорей, он очень мешает работе кабака.#author:mari
~ take_keys = true
+ Чем же он так мешает?#author:fedor
+ [Забрать ключи и уйти] -> END
- Кухарки боятся спускаться за продуктами и идут туда только когда уже совсем ничего не осталось. #author:mari
+ Хмм, а они рассказывали, что их так пугает? #author:fedor
-> details
+ Ну что ж, пойду посмотрю, что там такого жуткого. #author:fedor
-> END



=== meet ===
Ну что, получилось избавиться от демона?#author:mari
+{ not liho_banished } {know_thing } Расскажите, пожалуйста, ещё раз: что говорят кухарки? #author:fedor
-> details
+{ not liho_banished } { not know_thing } Что рассказывают кухарки? #author:fedor
-> details
+{ liho_banished }  Да, я закончил. #author:fedor
-> END



=== details ===
~ know_thing = true
Они говорят, что слышали, как кто-то ходит в подвале, чего быть не может, ведь мы всегда закрываем его на замок.#author:mari
Одна из них твердит, что видела, кого-то в углу подвала, после этого она ни в какую не хочет спускаться в подвал.#author:mari
Те, кто ещё ходят туда, рассказывают, что подвал давит на них, когда они заходят туда то на них нападает уныние и грусть, такие, что некоторым жить не хочется. Но когда они выходят оттуда, то их отпускает.#author:mari
-> END


=== end_dialogue ===
Спасибо за помощь! #author:mari
-> END