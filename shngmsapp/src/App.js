import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import './App.css';

function App() {
  return (
    <Router>
      <header className="app-header">
        <h1 className="app-title">Home</h1>
        <nav className="nav-bar">
          <ul className="nav-list">
            <li><Link to="/grant-applications">Grant Applications</Link></li>
            <li><Link to="/grant-review">Grant Review</Link></li>
            <li><Link to="/grant-management">Grant Management</Link></li>
            <li><Link to="/financial-management">Financial Management</Link></li>
            <li><Link to="/reporting-analytics">Reporting & Analytics</Link></li>
            <li><Link to="/user-management">User Management</Link></li>
            <li><Link to="/notifications-alerts">Notifications & Alerts</Link></li>
            <li><Link to="/system-settings">System Settings</Link></li>
          </ul>
        </nav>
      </header>

      <main className="main-content">
        <Routes>
          <Route path="/" element={<GrantSummary />} />
          <Route path="/grant-applications" element={<GrantApplications />} />
          <Route path="/grant-review" element={<GrantReview />} />
          <Route path="/grant-management" element={<GrantManagement />} />
          <Route path="/financial-management" element={<FinancialManagement />} />
          <Route path="/reporting-analytics" element={<ReportingAnalytics />} />
          <Route path="/user-management" element={<UserManagement />} />
          <Route path="/notifications-alerts" element={<NotificationsAlerts />} />
          <Route path="/system-settings" element={<SystemSettings />} />
        </Routes>
      </main>

      <footer className="app-footer">
        <p>&copy; 2024 Second Harvest Northland</p>
      </footer>
    </Router>
  );
}

// Example of one of the page components
function GrantSummary() {
  return (
    <section id="grant-summary">
      <h2>Grant Summary</h2>
      <p>Grant summary content...</p>
    </section>
  );
}

function GrantApplications() {
  return <div>Grant Applications Page</div>;
}

function GrantReview() {
  return <div>Grant Review Page</div>;
}

function GrantManagement() {
  return <div>Grant Management Page</div>;
}

function FinancialManagement() {
  return <div>Financial Management Page</div>;
}

function ReportingAnalytics() {
  return <div>Reporting & Analytics Page</div>;
}

function UserManagement() {
  return <div>User Management Page</div>;
}

function NotificationsAlerts() {
  return <div>Notifications & Alerts Page</div>;
}

function SystemSettings() {
  return <div>System Settings Page</div>;
}

export default App;
