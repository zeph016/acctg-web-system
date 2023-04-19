function CountTableColumns(id) {
    var table = document.getElementById(id);
    // var columnCount = table.tBodies[0].rows.Length;
    // var columnCount = table.rows.length; // 5
    var columnCount = table.querySelectorAll("th").length;
    return columnCount;
  }