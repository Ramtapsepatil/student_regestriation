import React, { useState, useEffect } from 'react';

const ClassPage = () => {
  const [classData, setClassData] = useState(null); // State to store fetched data

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('https://localhost:7247/'); // Replace with your API endpoint
        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        const data = await response.json();
        setClassData(data); // Update state with fetched data
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData(); // Call the fetchData function when component mounts

   
    return () => {
      // Cleanup code here
    };
  }, []); // Empty dependency array ensures this effect runs only once, similar to componentDidMount

  return (
    <div>
      <h2>Class Page</h2>
      {/* Render class-related content here */}
      {classData && (
        <div>
          <h3>Class Information</h3>
          <p>Class Name: {classData.name}</p>
          {/* Render other class data as needed */}
        </div>
      )}
    </div>
  );
};

export default ClassPage;
