SELECT b.start_datetime, b.end_datetime, b.people_id, b.statuses_id, bl.bookings_id, bl.items_id,
    it.name AS 'item_type_name', it.id AS 'item_type_id',
    kt.description, kt.weight_limit, kt.length_meter, kt.person_capacity
FROM bookings b
JOIN booking_line bl ON bl.bookings_id = b.id
JOIN items i ON bl.items_id = i.id
JOIN item_types it ON i.item_types_id = it.id
JOIN kayak_types kt ON it.id = kt.item_types_id
WHERE bl.items_id IN
(
    SELECT i.id
    FROM items i
    WHERE i.organisations_id = 1
)
AND GETDATE() < b.end_datetime