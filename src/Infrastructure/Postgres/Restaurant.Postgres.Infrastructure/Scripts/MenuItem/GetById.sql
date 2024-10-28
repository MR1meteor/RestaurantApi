SELECT id      as "Id",
       menu_id as "MenuId",
       dish_id as "DishId",
       price   as "Price"
FROM menu_items
WHERE id = @Id