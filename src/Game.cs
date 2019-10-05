// @file Game.cs
// @author Joseph Miles <jospehmiles2015@gmail.com>
// @date 2019-10-04
//
// This declares the behavior of our game.

using System;

class Game
{
    private const int MYSTERY_MAX_VALUE = 100;

    public int    mystery = 0;
    public int    guess   = 0;
    public IState state   = null;
    public bool   won     = false;

    public Game()
    {
        mystery = ((new Random()).Next() % MYSTERY_MAX_VALUE) + 1;
        state = new InitialState();
    }

    public bool run()
    {
        state = state.handle(this);

        return (state is ExitState);
    }
}
