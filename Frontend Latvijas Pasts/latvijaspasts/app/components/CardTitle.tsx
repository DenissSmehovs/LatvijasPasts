interface Props{
    FirstName: string;
    LastName: string;
}

export const CardTitle = ({FirstName , LastName}: Props) => {
    return (
        <div
        style={{
            display: "flex",
            flexDirection: "row",
            alignItems: "center",
            justifyContent: "space-between",
        }}
        >
            <p className="card__FirstName">{FirstName}</p>
            <p className="card__LastName">{LastName}</p>
        </div>
    )
}