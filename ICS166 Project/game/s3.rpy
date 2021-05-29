# The script of the game goes in this file.

# Declare characters used by this game. The color argument colorizes the
# name of the character.

define z = Character("Zeus")
define f = Character("Farmer")
define t1 = Character("Teen1")


# The game starts here.

label s3:

    # Show a background. This uses a placeholder by default, but you can
    # add a file (named either "bg room.png" or "bg room.jpg") to the
    # images directory to show it.

    scene bg room



    #add an intro dialogue with farmer
    show zeus normal at top
    z "Who is this peasant who stand before me?"

    "*snap*"
    z "AND WHAT IS THAT INFERNAL NOISE!?"

    "aaaaaaaand got it! That one was perfect!"
    hide zeus normal

    show farmer normal at topleft
    f "What the..."
    hide farmer normal

    show teen1 normal at topright
    t1 "Those selfies are gonna bring home sooooo many followers tonight."
    t1 "Wait, who are you guys?"
    hide teen1

    show zeus normal at topleft
    z "You dare ask me my nam -"
    hide zeus

    show farmer normal at topleft
    f "Hold on a second, Zeus. Between some of her nonsense, I heard her mention something about followers."
    f "Didn't you say you were powerless without them?"
    hide farmer

    show teen1 normal at topright
    t1 "OMG I'd be so powerless too without my beautiful people!!"
    hide teen1

    show zeus normal at topleft
    z "Please, humble farmer... don't tell me she is some sort of..."
    z "\"Modern God\"..."

    show farmer normal at topright
    f "I don't think so."
    f "I think she's using her cell phone to get people to look at pictures of her."
    z "Cell - .. phone?"
    f "Yeah. People use them all over the world to talk to eachother nowadays."
    z "Where is yours?"
    f "I don't use government tracking devices. It's what they want, you know."
    f "Anyway, maybe she can help you."
    z "Pfft..."
    f "I guess its back to the farmhouse?"
    z " .. I guess I'd be willing to try."
    hide zeus
    hide farmer

    show teen1 normal at top
    t1 "Well if you want to start using social media, you'll need a phone!"
    hide teen1
    show teen1 normal at topright
    show zeus normal at topleft
    "She hands Zeus a phone"
    z "That was easy.."
    t1 "Yeah I've got lots of them. I'll tell you a secret - half my followers are these other phones I have."
    t1 "PLEASE DON'T TELL ANYONE!"
    z "I don't care. Just tell me how to acquire these followers. What's \"Social Media\"?"
    t1 "Well, you see, "
    show bg room
    with fade
    z "That's... a lot."
    t1 "Yeah, well just remember the important bits. Do some interesting stuff, upload it online, and you'll get followers!"
    z "I'll become more powerful with my followers returning to me?"
    t1 "I don't know man, that's your thing. I've got somewhere to be, good luck!"
    hide teen1
    hide zeus
    show zeus normal at topleft
    show farmer normal at topright
    f "Finally she's gone. Now how are you going to use that contraption to get you off my property faster?"
    z "Patience, humble farmer, I have some ideas."
    hide zeus
    hide farmer

    show bg room
    with fade
    show farmer normal at top
    f "For all the viewers at home, there is a cow here... with a cowboy hat on."
    f "it's the best we've got."
    "*recording finished!*"
    hide farmer
    show farmer at topright
    show zeus at topleft
    z "Okay, let's see how that does."
    z "And... upload!"
    "SHOW UI OF FOLLOWER COUNT INCREASING MARGINALLY"
    f ".... Zeus?"
    hide farmer
    hide zeus
    show zeus at top
    z "ALL..... THIS....."
    z ".................."
    z "POWERRRRRRRRRRRRRRRRRR!"
    "Zeus holds his hands high"
    "a tiny spark emerges from his fingertips, then dissipates"
    z ".... Aw."
    f "Damn, well you really are the real deal. But you'll need more than that, huh?"
    "End of scene"


    return
