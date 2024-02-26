import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';

const MasterPage = () => {
  const history = useHistory();
  const [userData, setUserData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("https://localhost:7247/", {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}` // Add your authentication token if needed
          }
        });
        if (!response.ok) {
          throw new Error('Failed to fetch user data');
        }
        const data = await response.json();
        setUserData(data); // Update state with fetched user data
      } catch (error) {
        console.error('Error fetching user data:', error);
      }
    };

    fetchData(); // Call the fetchData function when component mounts

    // Cleanup function if needed
    return () => {
      // Cleanup code here
    };
  }, []); // Empty dependency array ensures this effect runs only once, similar to componentDidMount

  const handleLogout = () => {
    localStorage.removeItem('token');
    history.push('/');
  };

  return (
    <div>
      <h2>Master Page</h2>
      {userData && (
        <div>
          <p>Welcome, {userData.username}!</p>
          {/* Render other user data as needed */}
        </div>
      )}
      <nav>
        <ul>
          <li><Link to="/students">Students</Link></li>
          <li><Link to="/classes">Classes</Link></li>
          <li><button onClick={handleLogout}>Logout</button></li>
        </ul>
      </nav>
    </div>
  );
};

export default MasterPage;
