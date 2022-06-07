[System.Serializable]
public struct Stats
{
    public int health;
    public int strength;
    public int mana;
    public int endurance;
    public int intelligence;

    public static Stats operator+(Stats operand1, Stats operand2)
    {
        Stats stats = new Stats()
        {
            health = operand1.health + operand2.health,
            strength = operand1.strength + operand2.strength,
            mana = operand1.mana + operand2.mana,
            endurance = operand1.endurance + operand2.endurance,
            intelligence = operand1.intelligence + operand2.intelligence,
        };

        return stats;
    }

    public static Stats operator-(Stats operand1, Stats operand2)
    {
        Stats stats = new Stats()
        {
            health = operand1.health - operand2.health,
            strength = operand1.strength - operand2.strength,
            mana = operand1.mana - operand2.mana,
            endurance = operand1.endurance - operand2.endurance,
            intelligence = operand1.intelligence - operand2.intelligence,
        };

        return stats;
    }

}