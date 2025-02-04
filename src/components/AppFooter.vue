<template>
  <footer class="footer">
    <div class="footer-content">
      <!--About us-->
      <section class="footer-section about-us">
        <h2 class="footer-title">About us</h2>
        <p>
          Καλώς ήρθατε στο E-Coffee, το μικρό σας διαδικτυακό καφεκοπτείο που
          φέρνει τις καλύτερες γεύσεις καφέ στην πόρτα σας. Είμαστε περήφανοι
          που προσφέρουμε εξαιρετικούς κόκκους καφέ και μια αποκλειστική συλλογή
          από χαρμάνια, κάψουλες και αξεσουάρ. Είμαστε εδώ για να κάνουμε κάθε
          γουλιά σας αξέχαστη!
        </p>
      </section>

      <!--Links-->
      <section class="footer-section links">
        <h2 class="footer-title">Κατηγορίες</h2>
        <ul>
          <li><router-link to="/varieties">Ποικιλίες</router-link></li>
          <li><router-link to="/capsules">Κάψουλες</router-link></li>
          <li><router-link to="/accessories">Αξεσουάρ</router-link></li>
          <li><router-link to="/machines">Μηχανές</router-link></li>
          <li><router-link to="/beverages">Ροφήματα</router-link></li>
        </ul>
      </section>

      <!--Social Media-->
      <sections class="footer-section social-media">
        <h2 class="footer-title">Ακολουθήστε μας</h2>
        <div class="social-icons">
          <a href="#" class="icon">Facebook</a>
          <a href="#" class="icon">Instagram</a>
          <a href="#" class="icon">Twitter</a>
        </div>
      </sections>
    </div>

    <!--Copyright-->
    <div class="copyright">
      <p>© 2024 Coffee Shop. All rights reserved.</p>
    </div>
  </footer>
</template>

<script>
export default {
  name: "AppFooter",
};
</script>

<style scoped>
/* General Footer Settings */
.footer {
  background-color: #282424;
  color: #fff;
  margin-top: auto;
}

.footer-content {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  align-items: flex-start;
  margin: auto;
  max-width: 1200px;
  margin-bottom: 10px;
  gap: 20px;
}

.footer-section {
  flex: 1;
  margin: 10px;
  min-width: 250px;
}

.footer-section h2 {
  font-size: 22px;
  margin-bottom: 12px;
  color: #faebd7;
}

.footer-section p,
.footer-section ul {
  font-size: 16px;
  line-height: 1.5;
}

.footer-section ul {
  list-style: none;
  padding: none;
}

.footer-section ul li a {
  color: #fff;
  text-decoration: none;
  transition: color 0.3s ease;
}

.footer-section ul li a:hover {
  color: #faebd7;
}

/* Social Media Icons */
.social-icons a {
  margin-right: 10px;
  color: #fff;
  text-decoration: none;
  font-size: 16px;
  border: 1px solid #fff;
  padding: 5px 10px;
  border-radius: 5px;
  transition: background-color 0.3s ease, color 0.3s ease;
}

.social-icons a:hover {
  background-color: #faebd7;
  color: #282424;
}

.copyright {
  margin: auto;
  text-align: center;
  background-color: #000;
}
</style>
