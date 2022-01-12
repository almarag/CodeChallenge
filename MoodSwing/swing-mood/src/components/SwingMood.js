import ReactDOM from 'react-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faGrinBeam, faFrownOpen } from "@fortawesome/free-solid-svg-icons"

export default function SwingMood() {

    var loop = () =>  {
        var row = [];

        for (var i = 1; i <=100; i++)
        {
            var isMultipleOfThree = (i % 3) == 0;
            var isMultipleOfFive = (i % 5) == 0;

            var rowOutput = 
            <>
                <tr>
                    <td className="ordinal">
                        {i}
                    </td>                        
                    <td>
                        <div className="icons">
                            {isMultipleOfThree && <><FontAwesomeIcon icon={faGrinBeam} /></>}
                            {isMultipleOfFive && <><FontAwesomeIcon icon={faFrownOpen} /></>}
                        </div>
                    </td>                                                
                </tr>                        
            </>;

            row.push(rowOutput);
        }
        return row;
    }

    return (
        <div>
            <table className="tblSwing">
                {
                    loop()
                }
            </table>
        </div>
    )
}