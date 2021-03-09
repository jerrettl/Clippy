function filter (filterFields) {
    var input, txtFilter, table, tr, text, found, i;
    input = document.getElementById("filter");
    txtFilter = input.value.toUpperCase();
    table = document.getElementById("tableBody");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        found = false;
        for (j = 0; j < filterFields.length; j++) {
            text = tr[i].getElementsByTagName("td")[filterFields[j]].innerHTML.toUpperCase();
            if (text.indexOf(txtFilter) > -1) {
                found = true;
                break;
            }
        }

        if (found) {
            tr[i].style.display = "";
        } else {
            tr[i].style.display = "none";
        }
    }
};
