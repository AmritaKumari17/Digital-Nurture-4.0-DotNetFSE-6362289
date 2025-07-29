import React, { useState } from "react";

function CurrencyConvertor() {
  const [rupees, setRupees] = useState("");
  const [euros, setEuros] = useState(null);
  const conversionRate = 0.011; // Example: 1 INR = 0.011 EUR

  const handleSubmit = (e) => {
    e.preventDefault(); // Prevent page reload
    const result = parseFloat(rupees) * conversionRate;
    setEuros(result.toFixed(2));
  };

  return (
    <div>
      <h2>Currency Converter (INR ➡️ EUR)</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="number"
          value={rupees}
          onChange={(e) => setRupees(e.target.value)}
          placeholder="Enter INR"
        />
        <button type="submit">Convert</button>
      </form>
      {euros !== null && <p>Converted Value: € {euros}</p>}
    </div>
  );
}

export default CurrencyConvertor;
