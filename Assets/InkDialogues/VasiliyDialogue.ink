INCLUDE globals.ink

VAR know_about_box = false


-> part1


=== part1 ===
Вот мы и встретились#author:vasil
+ А ты ещё кто такой?#author:fedor
-Исаев Василий Александрович, хозяин этого поместья и автор того письма, что ты получил два дня назад.#author:vasil
+ То есть ты подделал государственное письмо?#author:fedor
-А ты не стал сообщать об ошибке.#author:vasil
+ Но мне были нужны деньги и...#author:fedor
-А мне был нужен экзорцист. Все кому я предлагал эту работу либо отказывались, либо заламывали такую цену, что я в жизни не смог бы с ними расплатиться.#author:vasil
+ Я бы тоже не согласился, это мне ещё повезло что он решил со мной поиграться, а не убил сразу.#author:fedor
-На твоём месте я бы начал меньше говорить и больше слушать *кладёт руку на рукоять револьвера*. #author:vasil
+ [* Слушать *] -> part2
+ { take_revolver } * Выстрелить *
~ orange_ending = true
-> END


=== part2 ===
Мне очень повезло что у нас с тобой одинаковые фамилии и отчества, и столь разные характеры. Ты настолько алчный, что я даже не сомневался в том, что ты поедешь сюда.#author:vasil
+ [* Слушать *]
-И ни одна из фатальных несостыковок не натолкнула тебя на мысль о том, что здесь что-то не чисто.#author:vasil
+ { not banish_ghost } Всё-таки натолкнула#author:fedor
~ green_ending = true
-> END
+ { banish_ghost } [* Слушать *]
И так, где же был заточён призрак?#author:vasil
-> question

=== question ====
+ [ Солгать ] -> lie
+ [ Сказать ] -> truth
+ { not know_about_box } Я не понимаю о чём ты#author:fedor
-> dont_know
+ { take_revolver } [* Выстрелить *]
~ orange_ending = true
-> END



=== lie ===
В граммофоне#author:fedor
А если сказать правду? *Взводит курок*#author:vasil
+ В шкатулке#author:fedor
-> part3

=== truth ===
В шкатулке#author:fedor
А если сказать правду? *Взводит курок*#author:vasil
+ Я сказал правду#author:fedor
-> part3

=== dont_know ===
Ты прекрасно понимаешь, призрак семейного проклятья привязывается к одной вещи, к какой именно?#author:vasil
~ know_about_box = true
-> question


=== part3 ===
Я тебе верю#author:vasil
{ not take_revolver: -> last_question }
+ { take_revolver } \* Василий тянется к револьверу, надо что-то делать, иначе живым мне не уйти *#author:fedor 
-> last_question


=== last_question ===
+ И что теперь?#author:fedor 
~ red_ending = true
-> END
+ { take_revolver } [* Выстрелить *]
~ orange_ending = true
-> END
