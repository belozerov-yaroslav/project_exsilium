INCLUDE globals.ink


Здравствуй, экзорцист#author:box
+ Я разговариваю со шкатулкой?#author:fedor
- Нет, Я - проклятье дома этой семьи.#author:box
+ \* Когда-то я слышал о таком призраке, он существует, пока не убьёт всех членов проклятой семьи *#author:fedor
- Я почувствовал, что ты очистил дом от демонов.#author:box
+ [* Слушать *]
- Мне никогда они не нравились. Этот смерд не занимается ничем, кроме распугивания людей, у них нет никакого предназначения.#author:box
+ [* Слушать *]
- Два года мне приходится делить с ними это поместье.#author:box
+ \* Демона семейного проклятия нельзя изгнать, его можно только убедить уйти добровольно. Нужно понять, как склонить его к этому *#author:fedor
- Мог бы я так же легко от них избавиться, как от людей...#author:box
+ ...#author:fedor
- Ты умён, экзорцист, скажи мне, каково твоё предназначение?#author:box
+ Изгнать всех демонов#author:fedor
+ Заработать денег#author:fedor
+ Дожить до старости#author:fedor
+ Оставить след в истории#author:fedor
+ Воспитать достойного сына#author:fedor
- Не понимаю зачем тебе это, но Я уважаю тебя и поэтому уважаю твоё предназначение.#author:box
+ [* Слушать *]
- Моё – избавиться от семьи Исаевых, но за два года нахождения здесь я убедился в его бессмысленности.#author:box
+ [* Убедить его уйти *] Почему бы тебе тогда просто не уйти?#author:fedor
-> quit
+ [* Убедить его остаться *] Чем ты тогда отличаешься от тех демонов, что я изгнал? Ты должен выполнить своё предназначение.#author:fedor
-> not_quit


=== quit ===
- Это звучит разумно, особенно из уст умного человека, вроде тебя.#author:box
+ Прощай
~banish_ghost=true
-> END


=== not_quit ===
- Ты прав. Как я мог думать о том, чтобы предать своё предназначение, предать себя.#author:box
+ Уйти
~banish_ghost=false
-> END