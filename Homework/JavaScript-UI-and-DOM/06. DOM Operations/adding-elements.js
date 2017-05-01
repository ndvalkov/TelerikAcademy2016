function () {

  return function (element, contents) {
      if (arguments.length < 2) {
          throw Error('Missing parameter');
      }

      if (!Array.isArray(contents)) {
          throw Error('The second parameter must be array');
      }

      var selected;

      // id provided
      if (typeof element === 'string') {
          selected = document.getElementById(element);

          if (selected === null) {
              throw Error('No element with the given ID exists');
          }
      } else if (element instanceof HTMLElement) {
          selected = element;
      } else {
          throw Error('Invalid first parameter');
      }

      element.innerHTML = '';
      var content = '';

      contents.forEach(function (x) {
          content += '<div>';
          if (typeof x !== 'string' && typeof x !== 'number') {
              throw Error('Invalid content');
          }
          content += x;
          content += '</div>';
      });

      selected.innerHTML = content;
  };
}