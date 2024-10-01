UPDATE menu_items
SET
    menu_id = @MenuId,
    dish_id = @DishId,
    price   = @Price
WHERE id = @Id