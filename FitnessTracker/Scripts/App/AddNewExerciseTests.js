$(document).ready(function () {

    $('#ShowNewDescriptionFormButton').on('click', function (event) {
        event.preventDefault();
        $('#ExerciseTypeDropdown').hide();
        $('#NewExerciseTypeForm').show();
    });

    $('#NewExerciseTypeCancelButton').on('click', function (event){
        event.preventDefault();
        $('#ExerciseTypeDropdown').show();
        $('#NewExerciseTypeForm').hide();

    });
    // api/ExerciseTypesApi
    $('#NewExerciseTypeOkButton').on('click', function (event) {
        event.preventDefault();

        $.post('/api/ExerciseTypesApi', {
            Description: $('#NewExerciseTypeDescription').val()
        }).done(function (data) {
            console.log(data);
            $('#ExerciseTypeID').append(new Option(data.Description, data.ExerciseTypeID));
            $('#ExerciseTypeID').val(data.ExerciseTypeID);
            $('#NewExerciseTypeDescription').val('');

            $('#ExerciseTypeDropdown').show();
            $('#NewExerciseTypeForm').hide();
        });
    });
});