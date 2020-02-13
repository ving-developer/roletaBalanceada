using System;

public class Preference
{
    private Object value;

    public Preference(Object value)
    {
        this.value = value;
    }

    public object Value
    {
        get => value;
        set => this.value = value;
    }

    public int getInt()
    {
        return int.Parse(value.ToString());
    }

    public int getPlus(int quanity)
    {
        value = getInt() + quanity;
        return getInt();
    }

    public int getLess(int quanity)
    {
        value = getInt()  - quanity;
        return getInt();
    }
}
