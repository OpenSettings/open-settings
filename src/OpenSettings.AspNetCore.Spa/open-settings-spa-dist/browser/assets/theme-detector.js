(function () {
  const savedThemePreference = localStorage.getItem('user_prefs_themePreference');
  const darkTheme = 'dark-theme';
  const edition = window['license'].edition

  document.body.classList.add(getEditionTheme(edition));

  switch (savedThemePreference) {
    case 'dark':
      document.body.classList.add(darkTheme);
      break;
    case 'system':
      const prefersDark = window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;
      if (prefersDark) {
        document.body.classList.add(darkTheme);
      }
      break;
    case 'auto':
      const hour = new Date().getHours();
      if (hour >= 18 || hour < 6) {
        document.body.classList.add(darkTheme);
      }
      break;
  }

})();

function getEditionTheme(edition) {
  switch (edition) {
    case 200:

      return 'personal-theme';

    case 300:

      return 'professional-theme';

    case 400: // Trial
    case 500: // Enterprise

      return 'enterprise-theme';

    default:

      return 'community-theme';
  }
}