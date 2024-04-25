INCLUDE globals.ink

{quest1_finished:
Спасибо за помощь #author:mari 
->END
}
{ quest1_firstMeet:-> first_meet }
->meet

=== first_meet ===
~ quest1_firstMeet = false
Эй, ты, да - ты, подойди сюда! #author:mari
Что такое, нельзя ли повежливее? #author:fedor
Сначала выслушай меня, а потом и о жизни поговорим. #author:mari
Есть у меня тайничок, спрятанной в пещере на юге, но ,по слухам, там обустроились мародёры, которые недавно обдирали близлежащие деревни, мне сейчас край нужена эта коробчонка, так что не мог бы ты сходить за ней? #author:mari
Я, конечно, в долгу не останусь, хотя человек небогатый, можешь рассчитывать на тёплый приём и кошель золотых. #author:mari
-> meet
    
    
=== meet ===
{quest1_accepted:-> quest_check} 
Ну так что? Возьмешься за задание?#author:mari
+Напомни, пожалуйста, где находится пещера с тайником?#author:fedor
    Отсюда надо направиться на юг.#author:mari -> meet
+[Принять задание] #author:fedor
    ~ quest1_accepted = true
    Хорошо, я выполню твоё поручение.#author:fedor 
    -> END
+Уйти#author:fedor
    -> END


=== quest_check ===
{quest1:-> quest_finish} 
Пещера находится на юге, принеси мне мою коробку.#author:mari
+ < завершить диалог > -> END


=== quest_finish ===
~ quest1_finished = true   
Огромное спасибо, вот твои деньги.#author:mari
+ < завершить диалог > -> END