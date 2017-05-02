function readyToGo() {
    console.log("I'm ready to go.");

    $('#startTimeNowButton').on('click', function (event) {
        event.preventDefault();

        console.log("button has been clicked yo");
        console.log(event);

        var currentTime = new Date();
        var formattedTime =
           (currentTime.getMonth()+ 1) + '/' +
            currentTime.getDate() +  '/'
           +currentTime.getFullYear() + ' '
           +currentTime.getHours() + ':' +
            currentTime.getMinutes();

        $('#StartTime').val(formattedTime);
    });


    $('#endTimeNowButton').on('click', function (event) {
        event.preventDefault();
      
        console.log("button has been clicked yo");
        console.log(event);

        var currentTime = new Date();
        var formattedTime =
            (currentTime.getMonth() + 1) + '/' +
            currentTime.getDate() + '/'
            + currentTime.getFullYear() + ' '
            + currentTime.getHours() + ':' +
            currentTime.getMinutes();

        $('#EndTime').val(formattedTime);
    });

}
$(document).ready(readyToGo);