INCLUDE globals.ink

{quest1_finished:Спасибо за помощь->END}
{ quest1_firstMeet:-> first_meet }
->meet

=== first_meet ===
~ quest1_firstMeet = false
Эй, ты, да - ты, подойди сюда!
Что такое, нельзя ли повежливее?
Сначала выслушай меня, а потом и о жизни поговорим.
Есть у меня тайничок, спрятанной в пещере на юге, но ,по слухам, там обустроились мародёры, которые недавно обдирали близлежащие деревни, мне сейчас край нужена эта коробчонка, так что не мог бы ты сходить за ней?
Я, конечно, в долгу не останусь, хотя человек небогатый, можешь рассчитывать на тёплый приём и кошель золотых.
-> meet
    
    
=== meet ===
{quest1_accepted:-> quest_check} 
Ну так что? Возьмешься за задание?
+Напомни, пожалуйста, где находится пещера с тайником?
    Отсюда надо направиться на юг. -> meet
+Принять задание #quest_give:quest1
    ~ quest1_accepted = true
    Хорошо, я выполню твоё поручение. -> END
+Уйти
    -> END


=== quest_check ===
{quest1:-> quest_finish} 
Пещера находится на юге, принеси мне мою коробку. 
-> END


=== quest_finish ===
~ quest1_finished = true   
Огромное спасибо, вот твои деньги.#quest_finish:quest1
-> END