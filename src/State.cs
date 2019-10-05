// @file State.cs
// @author Joseph Miles <josephmiles2015@gmail.com>
// @date 2019-10-04
//
// This is defines the states that the Guessing Game program can take.
//
// 1. Initial state. -> Guess State
// 2. Guess state. -> Evaluate State
// 3. Evaluate state. -> Guess State, Exit State
// 4. Exit state.

using System;

interface IState
{
    IState handle(Game game);
}


class InitialState : IState
{
    public IState handle(Game game)
    {
        // TODO[joe] Set this up such that we can change the upper limit value
        // by changing the game's upper limit.
        Console.WriteLine("Guess my number! (Hint: It's between 1 and 100)");

        return new GuessState();
    }
}

class GuessState : IState
{
    public IState handle(Game game)
    {
        Console.Write("What's you're guess?\t");

        try
        {
            game.guess = Convert.ToInt32(Console.ReadLine());

            return new EvaluateState();
        }
        catch (Exception e)
        {
            return new ExitState();
        }

    }
}

class EvaluateState : IState
{
    public IState handle(Game game)
    {
        if (game.guess == game.mystery)
        {
            Console.WriteLine("You guessed my number!");

            game.won = true;

            return new ExitState();
        }

        else if (game.guess > game.mystery)
        {
            Console.WriteLine("Oops, you guessed to high!");

            return new GuessState();
        }

        else if (game.guess < game.mystery)
        {
            Console.WriteLine("Oops, you guessed to low!");

            return new GuessState();
        }

        // TODO[joe] Implement error state?
        else
        {
            return this;
        }
    }
}

class ExitState : IState
{
    public IState handle(Game game) { return this; }
}
