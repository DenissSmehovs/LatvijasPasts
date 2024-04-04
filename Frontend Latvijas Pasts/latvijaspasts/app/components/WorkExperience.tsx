import React from 'react';
import Input from "antd/es/input";

interface Props {
    value: WorkExperience;
    onChange: (newValue: WorkExperience) => void;
  }

  const WorkExperienceInput: React.FC<Props> = ({ value, onChange }) => {
    return (
      <>
        <Input
          value={value?.companyName || ""}
          onChange={(e) => onChange({ ...value, companyName: e.target.value })}
          placeholder="Company Name"
        />
        <Input
          value={value?.position || ""}
          onChange={(e) => onChange({ ...value, position: e.target.value })}
          placeholder="Position"
        />
        <Input
          value={value?.yearsOfExperience || ""}
          onChange={(e) => onChange({ ...value, yearsOfExperience: e.target.value })}
          placeholder="Years of Experience"
        />
        <Input
          value={value?.description || ""}
          onChange={(e) => onChange({ ...value, description: e.target.value })}
          placeholder="Description"
        />
      </>
    );
  };

  export default WorkExperienceInput;