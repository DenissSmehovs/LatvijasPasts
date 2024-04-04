import React from 'react';
import Input from "antd/es/input";

interface Props {
    value: Education;
    onChange: (newValue: Education) => void;
  }

  const EducationInput: React.FC<Props> = ({ value, onChange }) => {
    return (
      <>
        <Input
          value={value?.institutionName || ""}
          onChange={(e) => onChange({ ...value, institutionName: e.target.value })}
          placeholder="Institution Name"
        />
        <Input
          value={value?.faculty || ""}
          onChange={(e) => onChange({ ...value, faculty: e.target.value })}
          placeholder="Faculty"
        />
        <Input
          value={value?.degree || ""}
          onChange={(e) => onChange({ ...value, degree: e.target.value })}
          placeholder="Degree"
        />
        <Input
          value={value?.status || ""}
          onChange={(e) => onChange({ ...value, status: e.target.value })}
          placeholder="Status"
        />
      </>
    );
  };

  export default EducationInput;