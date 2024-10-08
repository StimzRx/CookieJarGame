using Godot;
using System;

/* File Name: ItemsManager.cs
 * Date Modified: 10/6/2024
 * Author(s): Skillful
 * Description: This Script handles the 
 * Items and how it interacts with other
 * nodes.
 */

public partial class ItemsManager : Node
{
    #region Variables:

    [Export] private int _maxItemSize = 3;
	[Export] private int _minItemSize = 0;
    [Export] private Node[] _items;
    [Export] private Node[] _itemGhosts;
    [Export] private Node _nextItem;
    [Export] private Node _storedItem;
    [Export] private Image _nextItemImage;
    [Export] private Image _storedItemImage;
    [Export] private Sprite2D[] _itemSprites;

    #endregion Variables

    #region Godot Behaviors:

    public override void _Ready()
    {
        PickNextItem();
    }

    #endregion Godot Behaviors

    #region Public Behaviors:

    public Node PickRandomItemForThrow()
    {
        var rng = new RandomNumberGenerator();
        int randomIndex = rng.RandiRange(_minItemSize, _maxItemSize + 1);

        if (randomIndex < _itemGhosts.Length)
        {
            Node randomItem = _itemGhosts[randomIndex];
            return randomItem;
        }

        return null;
    }

    public void PickNextItem()
    {
        GD.Print("Picked Next Item");
    }

    public void StoreItem()
    {
        GD.Print("Stored Item");
    }

    public void SwitchItems()
    {
        GD.Print("Switched Item");
    }

    #region Getters:

    public Node GetNextItem()
    {
        return _nextItem;
    }

    public Node[] GetItems()
    {
        return _items;
    }

    public Node[] GetItemGhosts()
    {
        return _itemGhosts;
    }

    #endregion Getters


    #endregion Public Behaviors


}
