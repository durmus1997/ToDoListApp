function deleteTodo(i)
{
    $.ajax({
        url: 'Home/Delete',
        type: 'POST',
        data: { id: i },
        success: function () {
            window.location.reload();
        }
    });
        
}

function populateForm(i)
{
    $.ajax({
        url: 'Home/PopulateForm',
        type: 'GET',
        data: { id: i },
        dataType: 'json',
        success: function (response) {
            console.log(response);
            $('#Todo_Id').val(response.id);
            $('#Todo_Title').val(response.title);
            $('#Todo_Type').val(response.type);
            $('#form-button').val("Update Todo");
            $('#form-action').attr("action", "/Home/Update");
        }
    });
}